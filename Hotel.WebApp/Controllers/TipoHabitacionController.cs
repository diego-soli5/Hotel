using Hotel.WebApp.Models;
using Hotel.WebApp.Models.TipoHabitacion;
using Hotel.WebApp.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class TipoHabitacionController : BaseController
    {
        private readonly ITipoHabitacionService tipoHabitacionService;

        public TipoHabitacionController(ITipoHabitacionService TipoHabitacionService)
        {
            this.tipoHabitacionService = TipoHabitacionService;
        }

        #region Leer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await tipoHabitacionService.GetAll(CurrentToken);

            var tipoHabitacionesDTO = result.Data;

            return View(tipoHabitacionesDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await tipoHabitacionService.GetAll(CurrentToken);

            var tipoHabitacionesDTO = result.Data;

            return PartialView("_TipoHabitacionTablePartial", tipoHabitacionesDTO);
        }
        #endregion

        #region Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoHabitacionCreateDTO tipoHabitacionCreateDTO)
        {
            var result = await tipoHabitacionService.Create(tipoHabitacionCreateDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Crear Tipo de Habitacion";

                return RedirectToAction(nameof(Index));
            }

            ViewData["ActionResult"] = result.Message;

            return View(tipoHabitacionCreateDTO);
        }
        #endregion

        #region Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await tipoHabitacionService.GetById(id, CurrentToken);

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TipoHabitacionDTO tipoHabitacionDTO)
        {
            var result = await tipoHabitacionService.Update(tipoHabitacionDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Editar Tipo de Habitacion";

                return RedirectToAction(nameof(Index));
            }

            ViewData["ActionResult"] = result.Message;

            return View(tipoHabitacionDTO);
        }
        #endregion

        #region Eliminar
        [HttpPost("TipoHabitacion/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            var result = await tipoHabitacionService.Delete(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }
        #endregion
    }
}
