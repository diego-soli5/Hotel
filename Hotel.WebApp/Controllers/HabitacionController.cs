using Hotel.WebApp.Models;
using Hotel.WebApp.Models.Habitacion;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.ViewModels.Habitacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class HabitacionController : BaseController
    {
        private readonly IHabitacionService habitacionService;
        private readonly ITipoHabitacionService tipoHabitacionService;

        public HabitacionController(IHabitacionService habitacionService,
                                    ITipoHabitacionService tipoHabitacionService)
        {
            this.habitacionService = habitacionService;
            this.tipoHabitacionService = tipoHabitacionService;
        }

        #region Leer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await habitacionService.GetAll(CurrentToken);

            var habitacionesDTO = result.Data;

            return View(habitacionesDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await habitacionService.GetAll(CurrentToken);

            var habitacionesDTO = result.Data;

            return PartialView("_HabitacionTablePartial", habitacionesDTO);
        }
        #endregion

        #region Crear
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var tipoHabitacionResult = await tipoHabitacionService.GetAll(CurrentToken);

            var lst = new List<SelectListItem>();

            tipoHabitacionResult.Data.ToList().ForEach(hs =>
            {
                lst.Add(new SelectListItem(hs.TcNomTipoHabitacion, hs.Id.ToString(), false));
            });

            var habitacionCreateViewModel = new HabitacionCreateViewModel();
            habitacionCreateViewModel.TipoHabitacionSelectListItems = lst;

            return View(habitacionCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HabitacionCreateDTO habitacionCreateDTO)
        {
            var result = await habitacionService.Create(habitacionCreateDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Crear Habitacion";

                return RedirectToAction(nameof(Index));
            }

            var tipoHabitacionResult = await tipoHabitacionService.GetAll(CurrentToken);

            var lst = new List<SelectListItem>();

            tipoHabitacionResult.Data.ToList().ForEach(hs =>
            {
                lst.Add(new SelectListItem(hs.TcNomTipoHabitacion, hs.Id.ToString(), hs.Id == habitacionCreateDTO.TnIdTipoHabitacion));
            });

            var habitacionCreateViewModel = new HabitacionCreateViewModel();
            habitacionCreateViewModel.TipoHabitacionSelectListItems = lst;
            habitacionCreateViewModel.Habitacion = habitacionCreateDTO;

            ViewData["ActionResult"] = result.Message;

            return View(habitacionCreateViewModel);
        }
        #endregion

        #region Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var habitacionResult = await habitacionService.GetById(id, CurrentToken);
            var tipoHabitacionResult = await tipoHabitacionService.GetAll(CurrentToken);

            var lst = new List<SelectListItem>();

            tipoHabitacionResult.Data.ToList().ForEach(hs =>
            {
                lst.Add(new SelectListItem(hs.TcNomTipoHabitacion, hs.Id.ToString(), hs.Id == habitacionResult.Data.TnIdTipoHabitacion));
            });

            var habitacionEditViewModel = new HabitacionEditViewModel();
            habitacionEditViewModel.Habitacion = habitacionResult.Data;
            habitacionEditViewModel.TipoHabitacionSelectListItems = lst;

            return View(habitacionEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(HabitacionDTO habitacionDTO)
        {
            var result = await habitacionService.Update(habitacionDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Editar Habitacion";

                return RedirectToAction(nameof(Index));
            }

            var tipoHabitacionResult = await tipoHabitacionService.GetAll(CurrentToken);
            
            var lst = new List<SelectListItem>();

            tipoHabitacionResult.Data.ToList().ForEach(hs =>
            {
                lst.Add(new SelectListItem(hs.TcNomTipoHabitacion, hs.Id.ToString(), hs.Id == habitacionDTO.TnIdTipoHabitacion));
            });

            var habitacionEditViewModel = new HabitacionEditViewModel();
            habitacionEditViewModel.Habitacion = habitacionDTO;
            habitacionEditViewModel.TipoHabitacionSelectListItems = lst;

            ViewData["ActionResult"] = result.Message;

            return View(habitacionEditViewModel);
        }
        #endregion

        #region Eliminar
        [HttpPost("Habitacion/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            var result = await habitacionService.Delete(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }
        #endregion
    }
}
