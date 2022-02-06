using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Service;

namespace WebMinhaFinancas.Controllers
{
    public class TypeFixedBillsController : Controller
    {
        private readonly TypeFixedBillsService _typeFixedBillsService;

        public TypeFixedBillsController(TypeFixedBillsService typeFixedBillsService)
        {
            _typeFixedBillsService = typeFixedBillsService;
        }

        public IActionResult Index()
        {
            var list = _typeFixedBillsService.FindAll();
            return View(list);
        }
    }
}
