using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.DTO.Cliente;
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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet(nameof(GetById) + "/{id}")]
        public IActionResult GetById(int id)
        {
            var clienteDTO = clienteService.GetById(id);

            var response = new Response(clienteDTO, null);

            return Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var clientesDTO = clienteService.GetAll();

            var response = new Response(clientesDTO, null);

            return Ok(response);
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create(ClienteCreateDTO clienteCrearDTO)
        {
            bool result = clienteService.Create(clienteCrearDTO);

            var response = new Response("Cliente creado correctamente.");

            return Ok(response);
        }

        [HttpPut(nameof(Update) + "/{id}")]
        public IActionResult Update(int id, ClienteDTO clienteDTO)
        {
            bool result = clienteService.Update(clienteDTO, id);

            var response = new Response("Cliente actualizado correctamente.");

            return Ok(response);
        }

        [HttpDelete(nameof(Delete) + "/{id}")]
        public IActionResult Delete(int id)
        {
            bool result = clienteService.Delete(id);

            var response = new Response("Cliente eliminado correctamente.");

            return Ok(response);
        }
    }
}
