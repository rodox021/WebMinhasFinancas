using System;
using System.Collections.Generic;
using System.Linq;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMinhaFinancas.Service
{
    public class UserService
    {
        private readonly WebMinhaFinancasContext _context;
        public UserService(WebMinhaFinancasContext context)
        {
            _context = context;
        }
        //----------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------
        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.OrderBy(u => u.FullName).ToListAsync();
        }
        public async Task InsertAsync(User user)
        {
            if (!await _context.User.AnyAsync(u => u.Email == user.Email && u.Password == user.Password))
            {
                user.CreateAt = user.CreateAt == null ? DateTime.Now : user.CreateAt;
                _context.Add(user);
                await _context.SaveChangesAsync();

            }

        }
        //----------------------------------------------------------------------------------------------
        public User FindByIdAsync(int id)
        {
            return _context.User.FirstOrDefault(obj => obj.Id == id);
        }
        //----------------------------------------------------------------------------------------------

        
        //----------------------------------------------------------------------------------------------
        public async Task<User> UserExist(LoginViewModel loginUser)
        {

            if (_context.User.Any(u => u.Email == loginUser.Email && u.Password == loginUser.Password))
            {

                return await _context.User.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            }
            else
            {
                return null;
            }

        }
        //----------------------------------------------------------------------------------------------
        public bool Exist(string email)
        {
           
            return _context.User.Any(u => u.Email.Equals(email));
        }
    }
}
