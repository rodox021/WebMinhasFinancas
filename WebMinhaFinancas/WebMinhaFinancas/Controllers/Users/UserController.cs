using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.Entitty;
using WebMinhaFinancas.Service;

namespace WebMinhaFinancas.Controllers.Users
{
    public class UserController : Controller
    {
        public readonly UserService _userService;
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(User user)
        {

            if (ModelState.IsValid)
            {
                await _userService.InsertAsync(user);

                HttpContext.Session.SetInt32("Id", user.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
