using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.Entitty;
using WebMinhaFinancas.Models.ViewModels.Users;
using WebMinhaFinancas.Service;

namespace WebMinhaFinancas.Controllers.Users
{
    public class UserController : Controller
    {
        public readonly UserService _userService;

        public UserController(UserService userService )
        {
            _userService = userService;
        }
        //----------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var list = await _userService.FindAllAsync();
            return View(list);
        }
        //----------------------------------------------------------------------------
        public IActionResult Registro()
        {
            return View();
        }
        //----------------------------------------------------------------------------
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
        //----------------------------------------------------------------------------
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                await HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
                return RedirectToAction(nameof(Registro));
            }


            
            return View();
        }
        //----------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.UserExist(loginUser);

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

            return View(loginUser);
        }
        //----------------------------------------------------------------------------
        public async Task <IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
        //----------------------------------------------------------------------------
        public JsonResult Exist(string email)
        {
            
            if (!_userService.Exist(email))
            {
                return Json(true);
            }
            return Json("Usuário já cadastro");
        }
        //----------------------------------------------------------------------------
        public IActionResult Auth()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
