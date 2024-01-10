using Hotel.WebApp.Models.Cliente;
using Hotel.WebApp.Models.HttpClienteService;

namespace Hotel.WebApp.Services.Abstractions
{
    public interface IClienteService
    {
        public Task<HttpRequestResult<ClienteDTO>> GetById(int id, string token);
        public Task<HttpRequestResult<List<ClienteDTO>>> GetAll(string token);
        public Task<HttpRequestResult<Response>> Create(ClienteCreateDTO clienteCrearDTO, string token);
        public Task<HttpRequestResult<Response>> Update(ClienteDTO clienteDTO, string token);
        public Task<HttpRequestResult<Response>> Delete(int id, string token);
    }
}
