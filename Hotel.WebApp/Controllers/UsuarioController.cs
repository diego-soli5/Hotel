using Hotel.WebApp.Filters;
using Hotel.WebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Models.Usuario;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await usuarioService.GetAll(CurrentToken);

            var clientesDTO = result.Data;

            return View(clientesDTO);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegisterDTO usuarioRegistrarDTO)
        {
            var result = await usuarioService.Register(usuarioRegistrarDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;

                return RedirectToAction(nameof(Index));
            }

            ViewData["ActionResult"] = result.Message;

            return View(usuarioRegistrarDTO);
        }

        [HttpGet("/Acceso/Login")]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null)
                ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost("/Acceso/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl)
        {
            var result = await usuarioService.Login(userName,password);

            if (result.Success)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.Data.TcNombre),
                    new Claim(ClaimTypes.Email,result.Data.TcCorreo),
                    new Claim("Token", result.Data.Token)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ViewData["LoginMessage"] = result.Message;

            return View();
        }

        [HttpGet("Acceso/Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        [HttpPost("Usuario/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            if (id == CurrentUserId)
            {
                respuesta.Message = "No puede eliminar su propio usuario.";
                respuesta.Success = false;

                return Ok(respuesta);
            }

            var result = await usuarioService.Delete(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await usuarioService.GetAll(CurrentToken);

            var clientesDTO = result.Data;

            return PartialView("_UsuarioTablePartial", clientesDTO);

        }
    }
}
