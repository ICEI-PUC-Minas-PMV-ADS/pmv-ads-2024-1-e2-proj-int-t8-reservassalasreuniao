using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace reserva_sala_reuniao.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
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

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}