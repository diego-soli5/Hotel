using Hotel.WebApp.Models.Cliente;
using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;

namespace Hotel.WebApp.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IHttpClientService httpClientService;
        private readonly ApiRoutesProvider routesProvider;

        public ClienteService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            this.httpClientService = httpClientService;
            this.routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<ClienteDTO>> GetById(int id, string token)
        {
            string url = routesProvider.Cliente.GetById + $"/{id}";

            var result = await httpClientService.Get<ClienteDTO>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<List<ClienteDTO>>> GetAll(string token)
        {
            string url = routesProvider.Cliente.GetAll;

            var result = await httpClientService.Get<List<ClienteDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Create(ClienteCreateDTO clienteCreateDTO, string token)
        {
            string url = routesProvider.Cliente.Create;

            var result = await httpClientService.Post<Response>(url, clienteCreateDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Update(ClienteDTO clienteDTO, string token)
        {
            string url = routesProvider.Cliente.Update + $"/{clienteDTO.Id}";

            var result = await httpClientService.Put<Response>(url, clienteDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Delete(int id, string token)
        {
            string url = routesProvider.Cliente.Delete + $"/{id}";

            var result = await httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
