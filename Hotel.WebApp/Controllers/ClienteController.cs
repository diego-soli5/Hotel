using Hotel.WebApp.Models;
using Hotel.WebApp.Models.Cliente;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        #region Leer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await clienteService.GetAll(CurrentToken);

            var clientesDTO = result.Data;

            return View(clientesDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await clienteService.GetAll(CurrentToken);

            var clientesDTO = result.Data;

            return PartialView("_ClienteTablePartial", clientesDTO);

        }
        #endregion

        #region Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClienteCreateDTO clienteCreateDTO)
        {
            var result = await clienteService.Create(clienteCreateDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Crear Cliente";

                return RedirectToAction(nameof(Index));
            }

            ViewData["ActionResult"] = result.Message;

            return View(clienteCreateDTO);
        }
        #endregion

        #region Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await clienteService.GetById(id, CurrentToken);

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ClienteDTO clienteDTO)
        {
            var result = await clienteService.Update(clienteDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Editar Cliente";

                return RedirectToAction(nameof(Index));
            }

            ViewData["ActionResult"] = result.Message;

            return View(clienteDTO);
        }
        #endregion

        #region Eliminar
        [HttpPost("Cliente/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            var result = await clienteService.Delete(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }
        #endregion

    }
}
