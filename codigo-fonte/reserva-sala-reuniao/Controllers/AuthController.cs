using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using reserva_sala_reuniao.Models;
using reserva_sala_reuniao.Servicos;
using reserva_sala_reuniao.Services;

namespace reserva_sala_reuniao.Servicos.Controllers
{
    [Route("[controller]")]  // Isso configura a rota base para este controlador.
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Garantir que a rota para o login GET seja /login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _authService.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email ou senha incorretos");
                return View("Login"); // Certifique-se que este é o caminho correto
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }     

        // GET: /auth/logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}