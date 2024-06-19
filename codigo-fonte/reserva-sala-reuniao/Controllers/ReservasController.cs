using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;

namespace reserva_sala_reuniao.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Reserva
                .Include(r => r.Sala)
                    .ThenInclude(s => s.Localizacao)
                .Include(r => r.Usuario);

            // Busca a reserva mais próxima
            var reservaMaisProxima = await _context.Reserva
                .Include(r => r.Sala)
                    .ThenInclude(s => s.Localizacao)
                .Include(r => r.Usuario)
                .Where(r => r.Data >= DateTime.Now)
                .OrderBy(r => r.Data)
                .FirstOrDefaultAsync();

            // Passa a reserva mais próxima para a view usando ViewBag
            ViewBag.ReservaMaisProxima = reservaMaisProxima;

            // Define a mensagem quando não houver reservas futuras
            if (reservaMaisProxima == null)
            {
                ViewBag.MensagemReserva = "Não há reservas futuras.";
            }

            return View(await appDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Sala)
                    .ThenInclude(s => s.Localizacao)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Data,HorasReservadas,SalaId,UsuarioId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome", reserva.SalaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome", reserva.SalaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", reserva.UsuarioId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao,Data,HorasReservadas,SalaId,UsuarioId")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome", reserva.SalaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Sala)
                    .ThenInclude(s => s.Localizacao)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(long id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
