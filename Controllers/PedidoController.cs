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
    public class PedidoController : Controller
    {
        private readonly Contexto _context;

        public PedidoController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pedido.Include(p => p.Cadastrovendedor).Include(p => p.Cliente);
            return View(await contexto.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cadastrovendedor)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["CadastrovendedorId"] = new SelectList(_context.Cadastrovendedor, "CadastrovendedorId", "Emailvendedor");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nomecliente");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,CadastrovendedorId,ClienteId,Dadosdopedido,Datadopedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastrovendedorId"] = new SelectList(_context.Cadastrovendedor, "CadastrovendedorId", "Emailvendedor", pedido.CadastrovendedorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nomecliente", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["CadastrovendedorId"] = new SelectList(_context.Cadastrovendedor, "CadastrovendedorId", "Emailvendedor", pedido.CadastrovendedorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nomecliente", pedido.ClienteId);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,CadastrovendedorId,ClienteId,Dadosdopedido,Datadopedido")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
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
            ViewData["CadastrovendedorId"] = new SelectList(_context.Cadastrovendedor, "CadastrovendedorId", "Emailvendedor", pedido.CadastrovendedorId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nomecliente", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cadastrovendedor)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedido == null)
            {
                return Problem("Entity set 'Contexto.Pedido'  is null.");
            }
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedido.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.Pedido?.Any(e => e.PedidoId == id)).GetValueOrDefault();
        }
    }
}
