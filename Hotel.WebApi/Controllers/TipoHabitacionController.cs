using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.DTO.TipoHabitacion;
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
    public class TipoHabitacionController : ControllerBase
    {
        private readonly ITipoHabitacionService tipoHabitacionService;

        public TipoHabitacionController(ITipoHabitacionService tipoHabitacionService)
        {
            this.tipoHabitacionService = tipoHabitacionService;
        }

        [HttpGet(nameof(GetById) + "/{id}")]
        public IActionResult GetById(int id)
        {
            var tipoHabitacionesDTO = tipoHabitacionService.GetById(id);

            var response = new Response(tipoHabitacionesDTO, null);

            return Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var tipoHabitacionesDTO = tipoHabitacionService.GetAll();

            var response = new Response(tipoHabitacionesDTO, null);

            return Ok(response);
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create(TipoHabitacionCreateDTO tipoHabitacionCreateDTO)
        {
            bool result = tipoHabitacionService.Create(tipoHabitacionCreateDTO);

            var response = new Response("Tipo de habitación creada correctamente.");

            return Ok(response);
        }

        [HttpPut(nameof(Update) + "/{id}")]
        public IActionResult Update(int id, TipoHabitacionDTO tipoHabitacionDTO)
        {
            bool result = tipoHabitacionService.Update(tipoHabitacionDTO, id);

            var response = new Response("Tipo de habitación actualizada correctamente.");

            return Ok(response);
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            bool result = tipoHabitacionService.Delete(id);

            var response = new Response("Tipo de habitación eliminada correctamente.");

            return Ok(response);
        }
    }
}
