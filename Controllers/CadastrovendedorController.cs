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
    public class CadastrovendedorController : Controller
    {
        private readonly Contexto _context;

        public CadastrovendedorController(Contexto context)
        {
            _context = context;
        }

        // GET: Cadastrovendedor
        public async Task<IActionResult> Index()
        {
              return _context.Cadastrovendedor != null ? 
                          View(await _context.Cadastrovendedor.ToListAsync()) :
                          Problem("Entity set 'Contexto.Cadastrovendedor'  is null.");
        }

        // GET: Cadastrovendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastrovendedor == null)
            {
                return NotFound();
            }

            var cadastrovendedor = await _context.Cadastrovendedor
                .FirstOrDefaultAsync(m => m.CadastrovendedorId == id);
            if (cadastrovendedor == null)
            {
                return NotFound();
            }

            return View(cadastrovendedor);
        }

        // GET: Cadastrovendedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastrovendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastrovendedorId,Nomevendedor,Cpfvendedor,Emailvendedor,Datanascimentovendedor")] Cadastrovendedor cadastrovendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastrovendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastrovendedor);
        }

        // GET: Cadastrovendedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastrovendedor == null)
            {
                return NotFound();
            }

            var cadastrovendedor = await _context.Cadastrovendedor.FindAsync(id);
            if (cadastrovendedor == null)
            {
                return NotFound();
            }
            return View(cadastrovendedor);
        }

        // POST: Cadastrovendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastrovendedorId,Nomevendedor,Cpfvendedor,Emailvendedor,Datanascimentovendedor")] Cadastrovendedor cadastrovendedor)
        {
            if (id != cadastrovendedor.CadastrovendedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrovendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrovendedorExists(cadastrovendedor.CadastrovendedorId))
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
            return View(cadastrovendedor);
        }

        // GET: Cadastrovendedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastrovendedor == null)
            {
                return NotFound();
            }

            var cadastrovendedor = await _context.Cadastrovendedor
                .FirstOrDefaultAsync(m => m.CadastrovendedorId == id);
            if (cadastrovendedor == null)
            {
                return NotFound();
            }

            return View(cadastrovendedor);
        }

        // POST: Cadastrovendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastrovendedor == null)
            {
                return Problem("Entity set 'Contexto.Cadastrovendedor'  is null.");
            }
            var cadastrovendedor = await _context.Cadastrovendedor.FindAsync(id);
            if (cadastrovendedor != null)
            {
                _context.Cadastrovendedor.Remove(cadastrovendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrovendedorExists(int id)
        {
          return (_context.Cadastrovendedor?.Any(e => e.CadastrovendedorId == id)).GetValueOrDefault();
        }
    }
}
