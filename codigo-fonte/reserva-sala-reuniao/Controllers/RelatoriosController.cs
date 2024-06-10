using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;
using reserva_sala_reuniao.Models.ViewModel;

namespace reserva_sala_reuniao.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Relatorio.ToListAsync());
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // POST: Usuarios/GerarRelatorio
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrosRelatorio(GerarRelatorioViewModel gerarRelatorioViewModel)
        {
            if (ModelState.IsValid)
            {
                var listaReservas = await _context.Reserva.Where(x => DateTime.Compare(x.Data, gerarRelatorioViewModel.DataFinal) <= 0 &&
                    DateTime.Compare(x.Data, gerarRelatorioViewModel.DataInicio) >= 0).ToListAsync();

                var listaSalas = await _context.Sala.ToListAsync();

                var listaLocalizacao = await _context.Localizacao.ToListAsync();

                var listaUsuarios = await _context.Usuario.ToListAsync();

                if (gerarRelatorioViewModel.IdTipo == 1)
                {
                    return View(from reserva in listaReservas
                                join usuario in listaUsuarios on reserva.UsuarioId equals usuario.Id into usuarioJoin
                                from usuario in usuarioJoin.DefaultIfEmpty()
                                group new { reserva, usuario } by new { reserva.UsuarioId, usuario.Nome } into grp
                                select new DadosRelatorio
                                {
                                    Id = grp.Key.UsuarioId,
                                    Nome = grp.Key.Nome,
                                    TotalHoras = grp.Sum(x => x.reserva.HorasReservadas).ToString(),
                                });
                }

                return View(from reserva in listaReservas
                       join sala in listaSalas on reserva.SalaId equals sala.Id into salaJoin
                       from sala in salaJoin.DefaultIfEmpty()
                       join localizacao in listaLocalizacao on sala.LocalizacaoId equals localizacao.Id into localizacaoJoin
                       from localizacao in localizacaoJoin.DefaultIfEmpty()
                       group new { reserva, localizacao } by new { reserva.SalaId, localizacao.Nome } into grp
                       select new DadosRelatorio
                       {
                           Id = grp.Key.SalaId,
                           Nome = grp.Key.Nome,
                           TotalHoras = grp.Sum(x => x.reserva.HorasReservadas).ToString(),
                       });

            }

            return View(new List<DadosRelatorio>());
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoRelatorioId,Arquivo")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TipoRelatorioId,Arquivo")] Relatorio relatorio)
        {
            if (id != relatorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioExists(relatorio.Id))
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
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var relatorio = await _context.Relatorio.FindAsync(id);
            if (relatorio != null)
            {
                _context.Relatorio.Remove(relatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioExists(long id)
        {
            return _context.Relatorio.Any(e => e.Id == id);
        }
    }
}
