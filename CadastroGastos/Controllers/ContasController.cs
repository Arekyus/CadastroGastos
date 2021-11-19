using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroGastos.Models;

namespace CadastroGastos.Controllers
{
    public class ContasController : Controller
    {
        private readonly BancoDeDados _context;

        public ContasController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contas == null)
            {
                return NotFound();
            }

            return View(contas);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Valor,DataPagamento,Ativo")] Contas contas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contas);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = await _context.Clientes.FindAsync(id);
            if (contas == null)
            {
                return NotFound();
            }
            return View(contas);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor,DataPagamento,Ativo")] Contas contas)
        {
            if (id != contas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasExists(contas.Id))
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
            return View(contas);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contas == null)
            {
                return NotFound();
            }

            return View(contas);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contas = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(contas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
