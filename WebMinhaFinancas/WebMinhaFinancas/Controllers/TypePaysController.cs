using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Controllers
{
    public class TypePaysController : Controller
    {
        private readonly WebMinhaFinancasContext _context;

        public TypePaysController(WebMinhaFinancasContext context)
        {
            _context = context;
        }

        // GET: TypePays
        public async Task<IActionResult> Index()
        {
            var webMinhaFinancasContext = _context.TypePay.Include(t => t.IconFont);
            return View(await webMinhaFinancasContext.ToListAsync());
        }

        // GET: TypePays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePay = await _context.TypePay
                .Include(t => t.IconFont)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typePay == null)
            {
                return NotFound();
            }

            return View(typePay);
        }

        // GET: TypePays/Create
        public IActionResult Create()
        {
            ViewData["IconId"] = new SelectList(_context.Icon, "Id", "Id");
            return View();
        }

        // POST: TypePays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Flag,IconId,Id,CreateAt,UpdateAt,DeletedAt")] TypePay typePay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typePay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IconId"] = new SelectList(_context.Icon, "Id", "Id", typePay.IconId);
            return View(typePay);
        }

        // GET: TypePays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePay = await _context.TypePay.FindAsync(id);
            if (typePay == null)
            {
                return NotFound();
            }
            ViewData["IconId"] = new SelectList(_context.Icon, "Id", "Id", typePay.IconId);
            return View(typePay);
        }

        // POST: TypePays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Flag,IconId,Id,CreateAt,UpdateAt,DeletedAt")] TypePay typePay)
        {
            if (id != typePay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typePay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePayExists(typePay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IconId"] = new SelectList(_context.Icon, "Id", "Id", typePay.IconId);
            return View(typePay);
        }

        // GET: TypePays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typePay = await _context.TypePay
                .Include(t => t.IconFont)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typePay == null)
            {
                return NotFound();
            }

            return View(typePay);
        }

        // POST: TypePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typePay = await _context.TypePay.FindAsync(id);
            _context.TypePay.Remove(typePay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypePayExists(int id)
        {
            return _context.TypePay.Any(e => e.Id == id);
        }
    }
}
