using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;

public IActionResult Create()
{
    ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome");
    ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome");

    // Preparar as opções de horários
    var horarios = new List<SelectListItem>();
    DateTime horaInicial = DateTime.Today.AddHours(8);  // Exemplo: Horário inicial às 08:00
    DateTime horaFinal = DateTime.Today.AddHours(18);   // Exemplo: Horário final às 18:00

    while (horaInicial <= horaFinal)
    {
        horarios.Add(new SelectListItem { Text = horaInicial.ToShortTimeString(), Value = horaInicial.ToShortTimeString() });
        horaInicial = horaInicial.AddMinutes(30);  // Adicionar 30 minutos
    }

    ViewBag.Horarios = horarios;

    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Descricao,Data,HorasReservadas,SalaId,UsuarioId")] Reserva reserva)
{
    if (ModelState.IsValid)
    {
        // Atribuir o valor selecionado no dropdown diretamente à propriedade HorasReservadas
        reserva.HorasReservadas = Request.Form["HorasReservadas"];

        _context.Add(reserva);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["SalaId"] = new SelectList(_context.Sala.Include(s => s.Localizacao), "Id", "Localizacao.Nome", reserva.SalaId);
    ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", reserva.UsuarioId);
    return View(reserva);
}
