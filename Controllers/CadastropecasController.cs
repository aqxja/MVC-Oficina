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
    public class CadastropecasController : Controller
    {
        private readonly Contexto _context;

        public CadastropecasController(Contexto context)
        {
            _context = context;
        }

        // GET: Cadastropecas
        public async Task<IActionResult> Index()
        {
              return _context.Cadastropecas != null ? 
                          View(await _context.Cadastropecas.ToListAsync()) :
                          Problem("Entity set 'Contexto.Cadastropecas'  is null.");
        }

        // GET: Cadastropecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastropecas == null)
            {
                return NotFound();
            }

            var Cadastropecas = await _context.Cadastropecas
                .FirstOrDefaultAsync(m => m.CadastropecasId == id);
            if (Cadastropecas == null)
            {
                return NotFound();
            }

            return View(Cadastropecas);
        }

        // GET: Cadastropecas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastropecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastropecasId,Nomepeca,Tipopeca,Valorpeca")] Cadastropecas Cadastropecas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Cadastropecas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Cadastropecas);
        }

        // GET: Cadastropecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastropecas == null)
            {
                return NotFound();
            }

            var Cadastropecas = await _context.Cadastropecas.FindAsync(id);
            if (Cadastropecas == null)
            {
                return NotFound();
            }
            return View(Cadastropecas);
        }

        // POST: Cadastropecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastropecasId,Nomepeca,Tipopeca,Valorpeca")] Cadastropecas Cadastropecas)
        {
            if (id != Cadastropecas.CadastropecasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Cadastropecas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastropecasExists(Cadastropecas.CadastropecasId))
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
            return View(Cadastropecas);
        }

        // GET: Cadastropecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastropecas == null)
            {
                return NotFound();
            }

            var Cadastropecas = await _context.Cadastropecas
                .FirstOrDefaultAsync(m => m.CadastropecasId == id);
            if (Cadastropecas == null)
            {
                return NotFound();
            }

            return View(Cadastropecas);
        }

        // POST: Cadastropecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastropecas == null)
            {
                return Problem("Entity set 'Contexto.Cadastropecas'  is null.");
            }
            var Cadastropecas = await _context.Cadastropecas.FindAsync(id);
            if (Cadastropecas != null)
            {
                _context.Cadastropecas.Remove(Cadastropecas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastropecasExists(int id)
        {
          return (_context.Cadastropecas?.Any(e => e.CadastropecasId == id)).GetValueOrDefault();
        }
    }
}
