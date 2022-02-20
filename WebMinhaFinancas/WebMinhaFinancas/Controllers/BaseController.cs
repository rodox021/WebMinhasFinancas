using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult Autenticado()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return null;
        }
    }
}
