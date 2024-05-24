using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;

namespace reserva_sala_reuniao.Controllers
{
    public class RelatorioTiposController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioTiposController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RelatorioTipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelatorioTipo.ToListAsync());
        }

        // GET: RelatorioTipos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioTipo = await _context.RelatorioTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioTipo == null)
            {
                return NotFound();
            }

            return View(relatorioTipo);
        }

        // GET: RelatorioTipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelatorioTipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] RelatorioTipo relatorioTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorioTipo);
        }

        // GET: RelatorioTipos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioTipo = await _context.RelatorioTipo.FindAsync(id);
            if (relatorioTipo == null)
            {
                return NotFound();
            }
            return View(relatorioTipo);
        }

        // POST: RelatorioTipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Descricao")] RelatorioTipo relatorioTipo)
        {
            if (id != relatorioTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioTipoExists(relatorioTipo.Id))
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
            return View(relatorioTipo);
        }

        // GET: RelatorioTipos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioTipo = await _context.RelatorioTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioTipo == null)
            {
                return NotFound();
            }

            return View(relatorioTipo);
        }

        // POST: RelatorioTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var relatorioTipo = await _context.RelatorioTipo.FindAsync(id);
            if (relatorioTipo != null)
            {
                _context.RelatorioTipo.Remove(relatorioTipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioTipoExists(long id)
        {
            return _context.RelatorioTipo.Any(e => e.Id == id);
        }
    }
}

