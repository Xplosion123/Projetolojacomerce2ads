using System.Security.Claims;
using LojaEcomerce.Interfaces;
using LojaEcomerce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LojaEcomerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Iusuariorepositorio _usuariorepositorio;

        public UsuarioController(Iusuariorepositorio usuariorepositorio)
        {
            _usuariorepositorio = usuariorepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid) return View(user);
            var Usuario = _usuariorepositorio.Validar(user.Email, user.Senha);

            if (Usuario != null)
            {
                //inicia a criacao de uma lista de claims(declarações)
                // pense com as informações que compoe o cracha

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , Usuario.Nome),
                    new Claim(ClaimTypes.Email, Usuario.Email),
                    new Claim("Nivelacesso", Usuario.Nivel),
                    new Claim("UsuarioID", Usuario.Id.ToString())
                };
                var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identidade),
                    new AuthenticationProperties { IsPersistent = false });
                    return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
