using Hotel.WebApp.Models;
using Hotel.WebApp.Models.Reservacion;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.ViewModels.Reservacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.WebApp.Controllers
{
    [Authorize]
    public class ReservacionController : BaseController
    {
        private readonly IHabitacionService habitacionService;
        private readonly IClienteService clienteService;
        private readonly IReservacionService reservacionService;

        public ReservacionController(IHabitacionService habitacionService,
                                     IClienteService clienteService,
                                     IReservacionService reservacionService)
        {
            this.habitacionService = habitacionService;
            this.clienteService = clienteService;
            this.reservacionService = reservacionService;
        }

        #region Leer
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await reservacionService.GetAll(CurrentToken);

            var reservacionesDTO = result.Data;

            return View(reservacionesDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTable()
        {
            var result = await reservacionService.GetAll(CurrentToken);

            var reservacionesDTO = result.Data;

            return PartialView("_ReservacionTablePartial", reservacionesDTO);
        }
        #endregion

        #region Crear
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var habitacionResult = await habitacionService.GetAll(CurrentToken);
            var clienteResult = await clienteService.GetAll(CurrentToken);

            var lstHabitaciones = new List<SelectListItem>();
            var lstClientes = new List<SelectListItem>();

            habitacionResult.Data.ToList().ForEach(hs =>
            {
                lstHabitaciones.Add(new SelectListItem(hs.TcNombreHabitacion, hs.Id.ToString(), false));
            });

            clienteResult.Data.ToList().ForEach(hs =>
            {
                lstClientes.Add(new SelectListItem($"{hs.TcNombre} {hs.TcAp1} {hs.TcAp2}", hs.Id.ToString(), false));
            });

            var reservacionCreateViewModel = new ReservacionCreateViewModel();
            reservacionCreateViewModel.HabitacionSelectListItems = lstHabitaciones;
            reservacionCreateViewModel.ClienteSelectListItems = lstClientes;

            return View(reservacionCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ReservacionCreateDTO reservacionCreateDTO)
        {
            var result = await reservacionService.Create(reservacionCreateDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Crear Reservacion";

                return RedirectToAction(nameof(Index));
            }

            var habitacionResult = await habitacionService.GetAll(CurrentToken);
            var clienteResult = await clienteService.GetAll(CurrentToken);

            var lstHabitaciones = new List<SelectListItem>();
            var lstClientes = new List<SelectListItem>();

            habitacionResult.Data.ToList().ForEach(hs =>
            {
                lstHabitaciones.Add(new SelectListItem(hs.TcNombreHabitacion, hs.Id.ToString(), hs.Id == reservacionCreateDTO.TnIdHabitacion));
            });

            clienteResult.Data.ToList().ForEach(cs =>
            {
                lstClientes.Add(new SelectListItem($"{cs.TcNombre} {cs.TcAp1} {cs.TcAp2}", cs.Id.ToString(), cs.Id == reservacionCreateDTO.TnIdCliente));
            });

            var reservacionCreateViewModel = new ReservacionCreateViewModel();
            reservacionCreateViewModel.HabitacionSelectListItems = lstHabitaciones;
            reservacionCreateViewModel.ClienteSelectListItems = lstClientes;
            reservacionCreateViewModel.Reservacion = reservacionCreateDTO;

            ViewData["ActionResult"] = result.Message;

            return View(reservacionCreateViewModel);
        }
        #endregion

        #region Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var reservacionResult = await reservacionService.GetById(id, CurrentToken);
            var habitacionResult = await habitacionService.GetAll(CurrentToken);
            var clienteResult = await clienteService.GetAll(CurrentToken);

            var lstHabitaciones = new List<SelectListItem>();
            var lstClientes = new List<SelectListItem>();

            habitacionResult.Data.ToList().ForEach(hs =>
            {
                lstHabitaciones.Add(new SelectListItem(hs.TcNombreHabitacion, hs.Id.ToString(), hs.Id == reservacionResult.Data.TnIdHabitacion));
            });

            clienteResult.Data.ToList().ForEach(cs =>
            {
                lstClientes.Add(new SelectListItem($"{cs.TcNombre} {cs.TcAp1} {cs.TcAp2}", cs.Id.ToString(), cs.Id == reservacionResult.Data.TnIdCliente));
            });

            var reservacionEditViewModel = new ReservacionEditViewModel();
            reservacionEditViewModel.HabitacionSelectListItems = lstHabitaciones;
            reservacionEditViewModel.ClienteSelectListItems = lstClientes;
            reservacionEditViewModel.Reservacion = reservacionResult.Data;

            return View(reservacionEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ReservacionDTO reservacionDTO)
        {
            var result = await reservacionService.Update(reservacionDTO, CurrentToken);

            if (result.Success)
            {
                TempData["ActionResult"] = result.Message;
                TempData["ActionResultType"] = "Editar Reservacion";

                return RedirectToAction(nameof(Index));
            }

            var habitacionResult = await habitacionService.GetAll(CurrentToken);
            var clienteResult = await clienteService.GetAll(CurrentToken);

            var lstHabitaciones = new List<SelectListItem>();
            var lstClientes = new List<SelectListItem>();

            habitacionResult.Data.ToList().ForEach(hs =>
            {
                lstHabitaciones.Add(new SelectListItem(hs.TcNombreHabitacion, hs.Id.ToString(), hs.Id == reservacionDTO.TnIdHabitacion));
            });

            clienteResult.Data.ToList().ForEach(cs =>
            {
                lstClientes.Add(new SelectListItem($"{cs.TcNombre} {cs.TcAp1} {cs.TcAp2}", cs.Id.ToString(), cs.Id == reservacionDTO.TnIdCliente));
            });

            var reservacionEditViewModel = new ReservacionEditViewModel();
            reservacionEditViewModel.HabitacionSelectListItems = lstHabitaciones;
            reservacionEditViewModel.ClienteSelectListItems = lstClientes;
            reservacionEditViewModel.Reservacion = reservacionDTO;

            ViewData["ActionResult"] = result.Message;

            return View(reservacionEditViewModel);
        }
        #endregion

        #region Eliminar
        [HttpPost("Reservacion/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            var result = await reservacionService.Delete(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }
        #endregion
    }
}
