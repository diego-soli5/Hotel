using Hotel.BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebApi.Models;
using Hotel.BusinessLogic.DTO.Usuario;
using Hotel.WebApi.CustomFilters;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            this.usuarioService = usuarioServicio;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var usuariosDTO = usuarioService.GetAll();

            return Ok(new Response(usuariosDTO, null));
        }

        [HttpPost(nameof(Login))]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDTO loginRequestDTO)
        {
            var resultado = usuarioService.Login(loginRequestDTO.UserName, loginRequestDTO.Password);

            return Ok(new Response(resultado, null));
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            var resultado = usuarioService.Register(registerDTO);

            var respuesta = new Response("Usuario registrado correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = usuarioService.Delete(id);

            var respuesta = new Response("Usuario eliminado correctamente.");

            return Ok(respuesta);
        }
    }
}
