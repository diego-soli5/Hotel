using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.DTO.Habitacion;
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
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionService habitacionService;

        public HabitacionController(IHabitacionService habitacionService)
        {
            this.habitacionService = habitacionService;
        }

        [HttpGet(nameof(GetById) + "/{id}")]
        public IActionResult GetById(int id)
        {
            var habitacionesDTO = habitacionService.GetById(id);

            var response = new Response(habitacionesDTO, null);

            return Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var habitacionesDTO = habitacionService.GetAll();

            var response = new Response(habitacionesDTO, null);

            return Ok(response);
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create(HabitacionCreateDTO habitacionCreateDTO)
        {
            bool result = habitacionService.Create(habitacionCreateDTO);

            var response = new Response("Habitación creada correctamente.");

            return Ok(response);
        }

        [HttpPut(nameof(Update) + "/{id}")]
        public IActionResult Update(int id, HabitacionDTO habitacionDTO)
        {
            bool result = habitacionService.Update(habitacionDTO, id);

            var response = new Response("Habitación actualizada correctamente.");

            return Ok(response);
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            bool result = habitacionService.Delete(id);

            var response = new Response("Habitación eliminada correctamente.");

            return Ok(response);
        }
    }
}
