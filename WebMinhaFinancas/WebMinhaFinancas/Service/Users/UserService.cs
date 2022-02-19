using System;
using System.Collections.Generic;
using System.Linq;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task InsertAsync(User user)
        {
            user.CreateAt = user.CreateAt == null ? DateTime.Now : user.CreateAt;
            _context.Add(user);
            await _context.SaveChangesAsync();

        }
        //----------------------------------------------------------------------------------------------
        public User FindByIdAsync(int id)
        {
            return _context.User.FirstOrDefault(obj => obj.Id == id);
        }
        //----------------------------------------------------------------------------------------------
       
    }
}
