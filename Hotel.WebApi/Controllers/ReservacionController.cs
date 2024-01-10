using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.DTO.Reservacion;
using Hotel.WebApi.CustomFilters;
using Hotel.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class ReservacionController : ControllerBase
    {
        private readonly IReservacionService reservacionService;

        public ReservacionController(IReservacionService habitacionService)
        {
            this.reservacionService = habitacionService;
        }

        [HttpGet(nameof(GetById) + "/{id}")]
        public IActionResult GetById(int id)
        {
            var reservacionesDTO = reservacionService.GetById(id);

            var response = new Response(reservacionesDTO, null);

            return Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var reservacionesDTO = reservacionService.GetAll();

            var response = new Response(reservacionesDTO, null);

            return Ok(response);
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create(ReservacionCreateDTO reservacionCreateDTO)
        {
            bool result = reservacionService.Create(reservacionCreateDTO);

            var response = new Response("Reservación creada correctamente.");

            return Ok(response);
        }

        [HttpPut(nameof(Update) + "/{id}")]
        public IActionResult Update(int id, ReservacionDTO reservacionDTO)
        {
            bool result = reservacionService.Update(reservacionDTO, id);

            var response = new Response("Reservación actualizada correctamente.");

            return Ok(response);
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            bool result = reservacionService.Delete(id);

            var response = new Response("Reservación eliminada correctamente.");

            return Ok(response);
        }
    }
}