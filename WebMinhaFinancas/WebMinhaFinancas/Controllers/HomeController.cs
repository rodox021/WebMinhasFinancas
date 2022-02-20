using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.ViewModels;
using WebMinhaFinancas.Controllers.Users;

namespace WebMinhaFinancas.Controllers
{
    public class HomeController : Controller
    {
              

        public IActionResult Index()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        public IActionResult About()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
           

                ViewData["Message"] = "Your application description page.";


            return View();
        }
        //-------------------------------------------------------------------------------
        public IActionResult Contact()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                ViewData["Message"] = "Rodolfo Braga";
                ViewData["Tel"] = "21 98747-8049";
                ViewData["LinkWA"] = "https://wa.me/5521987478049";
                ViewData["Linkdin"] = "https://www.linkedin.com/in/rodolfolealbraga";
            }
            return View();
        }
        //-------------------------------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
