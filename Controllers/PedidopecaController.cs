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
    public class PedidopecaController : Controller
    {
        private readonly Contexto _context;

        public PedidopecaController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedidopeca
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pedidopeca.Include(p => p.Pedido);
            return View(await contexto.ToListAsync());
        }

        // GET: Pedidopeca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidopeca == null)
            {
                return NotFound();
            }

            var pedidopeca = await _context.Pedidopeca
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidopecaId == id);
            if (pedidopeca == null)
            {
                return NotFound();
            }

            return View(pedidopeca);
        }

        // GET: Pedidopeca/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            return View();
        }

        // POST: Pedidopeca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidopecaId,PedidoId,CadastropecasId")] Pedidopeca pedidopeca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidopeca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidopeca.PedidoId);
            return View(pedidopeca);
        }

        // GET: Pedidopeca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidopeca == null)
            {
                return NotFound();
            }

            var pedidopeca = await _context.Pedidopeca.FindAsync(id);
            if (pedidopeca == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidopeca.PedidoId);
            return View(pedidopeca);
        }

        // POST: Pedidopeca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidopecaId,PedidoId,CadastropecasId")] Pedidopeca pedidopeca)
        {
            if (id != pedidopeca.PedidopecaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidopeca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidopecaExists(pedidopeca.PedidopecaId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", pedidopeca.PedidoId);
            return View(pedidopeca);
        }

        // GET: Pedidopeca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidopeca == null)
            {
                return NotFound();
            }

            var pedidopeca = await _context.Pedidopeca
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidopecaId == id);
            if (pedidopeca == null)
            {
                return NotFound();
            }

            return View(pedidopeca);
        }

        // POST: Pedidopeca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidopeca == null)
            {
                return Problem("Entity set 'Contexto.Pedidopeca'  is null.");
            }
            var pedidopeca = await _context.Pedidopeca.FindAsync(id);
            if (pedidopeca != null)
            {
                _context.Pedidopeca.Remove(pedidopeca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidopecaExists(int id)
        {
          return (_context.Pedidopeca?.Any(e => e.PedidopecaId == id)).GetValueOrDefault();
        }
    }
}
