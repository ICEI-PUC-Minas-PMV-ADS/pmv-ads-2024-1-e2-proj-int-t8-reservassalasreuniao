using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserva_sala_reuniao.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using reserva_sala_reuniao.Models.ViewModel;

namespace reserva_sala_reuniao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var listaUsuario = await _context.Usuario.ToListAsync();
            var listaSetor = await _context.Setor.ToListAsync();
            var listaCargo = await _context.Cargos.ToListAsync();

            var viewModelUsuario =
                from usuario in listaUsuario
                join setor in listaSetor
                on usuario.SetorId equals setor.Id
                join cargo in listaCargo
                on usuario.CargoId equals cargo.Id
                select new UsuarioViewModel
                {
                    NomeCargo = cargo.Nome,
                    Perfil = usuario.Perfil,
                    NomeSetor = setor.Nome,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Id = usuario.Id,
                };

            return View(viewModelUsuario);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var dados = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (dados == null || !BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha))
            {
                ViewBag.Message = "Email e/ou senha inválidos!";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, dados.Email),
                new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                new Claim(ClaimTypes.Name, dados.Nome),
                new Claim(ClaimTypes.Role, dados.Perfil.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuarios");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Cargo)
                .Include(u => u.Setor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [HttpGet]
        public async Task<IActionResult> Create(long? id)
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Nome");
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Nome");

            if (id == null)
                return View(new Usuario());

            else
                return View(await _context.Usuario.FirstAsync(x => x.Id == id));
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var usuarioCadastrado = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == usuario!.Id);

            if (usuarioCadastrado != null && !string.IsNullOrEmpty(usuario.Nome) && !string.IsNullOrEmpty(usuario.Email))
            {
                usuarioCadastrado.Email = usuario.Email;
                usuarioCadastrado.SetorId = usuario.SetorId;
                usuarioCadastrado.CargoId = usuario.CargoId;
                usuarioCadastrado.Nome = usuario.Nome;
                usuarioCadastrado.Perfil = usuario.Perfil;

                _context.Update(usuarioCadastrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else if (ModelState.IsValid && usuarioCadastrado == null)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                await _context.AddAsync(usuario);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Nome", usuario.CargoId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Nome", usuario.SetorId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Nome", usuario.CargoId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Nome", usuario.SetorId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Email,Senha,SetorId,CargoId,Perfil")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Nome", usuario.CargoId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "Nome", usuario.SetorId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Cargo)
                .Include(u => u.Setor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}