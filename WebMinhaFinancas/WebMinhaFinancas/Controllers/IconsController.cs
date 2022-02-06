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
    public class IconsController : Controller
    {
        private readonly WebMinhaFinancasContext _context;

        public IconsController(WebMinhaFinancasContext context)
        {
            _context = context;
        }

        // GET: Icons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Icon.ToListAsync());
        }

        // GET: Icons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icon == null)
            {
                return NotFound();
            }

            return View(icon);
        }

        // GET: Icons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Icons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,iconName,icon")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(icon);
        }

        // GET: Icons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icon.FindAsync(id);
            if (icon == null)
            {
                return NotFound();
            }
            return View(icon);
        }

        // POST: Icons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,iconName,icon")] Icon icon)
        {
            if (id != icon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IconExists(icon.Id))
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
            return View(icon);
        }

        // GET: Icons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icon == null)
            {
                return NotFound();
            }

            return View(icon);
        }

        // POST: Icons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var icon = await _context.Icon.FindAsync(id);
            _context.Icon.Remove(icon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IconExists(int id)
        {
            return _context.Icon.Any(e => e.Id == id);
        }
    }
}
