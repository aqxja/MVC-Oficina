using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api_Oficina.Models;

namespace Api_Oficina.Controllers
{
    public class PremiumController : Controller
    {
        private readonly Contexto _context;

        public PremiumController(Contexto context)
        {
            _context = context;
        }

        // GET: Premium
        public async Task<IActionResult> Index()
        {
              return _context.Premium != null ? 
                          View(await _context.Premium.ToListAsync()) :
                          Problem("Entity set 'Contexto.Premium'  is null.");
        }

        // GET: Premium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.PremiumId == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // GET: Premium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Premium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PremiumId,Tipodepremium,Descontodopremium")] Premium premium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(premium);
        }

        // GET: Premium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium.FindAsync(id);
            if (premium == null)
            {
                return NotFound();
            }
            return View(premium);
        }

        // POST: Premium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PremiumId,Tipodepremium,Descontodopremium")] Premium premium)
        {
            if (id != premium.PremiumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremiumExists(premium.PremiumId))
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
            return View(premium);
        }

        // GET: Premium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.PremiumId == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // POST: Premium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Premium == null)
            {
                return Problem("Entity set 'Contexto.Premium'  is null.");
            }
            var premium = await _context.Premium.FindAsync(id);
            if (premium != null)
            {
                _context.Premium.Remove(premium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremiumExists(int id)
        {
          return (_context.Premium?.Any(e => e.PremiumId == id)).GetValueOrDefault();
        }
    }
}
