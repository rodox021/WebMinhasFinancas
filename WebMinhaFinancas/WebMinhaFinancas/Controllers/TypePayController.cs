using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.Entitty;
using WebMinhaFinancas.Models.ViewModels.ViewModelsTypePay;
using WebMinhaFinancas.Service;

namespace WebMinhaFinancas.Controllers
{
    public class TypePayController : Controller
    {
        private readonly TypePayService _typePayService;
        private readonly IconService _iconService;
       

        public TypePayController(TypePayService typePayService, IconService iconService)
        {
            _typePayService = typePayService;
            _iconService = iconService;
        }

        public IActionResult Index()
        {
            var list = _typePayService.FindAll();
            
            return View(list);
        }
        public IActionResult Create()
        {
            var icons = _iconService.FindAll();
            var viewModels = new TypePayFormViewModel { Icon = icons };
            return View(viewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypePay typePay)
        {
            _typePayService.Insert(typePay);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            _typePayService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
