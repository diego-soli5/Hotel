using Hotel.WebApp.Models.Habitacion;
using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;

namespace Hotel.WebApp.Services
{
    public class HabitacionService : BaseService, IHabitacionService
    {
        private readonly IHttpClientService httpClientService;
        private readonly ApiRoutesProvider routesProvider;

        public HabitacionService(IHttpClientService httpClientService,
                                 ApiRoutesProvider routesProvider)
        {
            this.httpClientService = httpClientService;
            this.routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<HabitacionDTO>> GetById(int id, string token)
        {
            string url = routesProvider.Habitacion.GetById + $"/{id}";

            var result = await httpClientService.Get<HabitacionDTO>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<List<HabitacionDTO>>> GetAll(string token)
        {
            string url = routesProvider.Habitacion.GetAll;

            var result = await httpClientService.Get<List<HabitacionDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Create(HabitacionCreateDTO habitacionCreateDTO, string token)
        {
            string url = routesProvider.Habitacion.Create;

            var result = await httpClientService.Post<Response>(url, habitacionCreateDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Update(HabitacionDTO habitacionDTO, string token)
        {
            string url = routesProvider.Habitacion.Update + $"/{habitacionDTO.Id}";

            var result = await httpClientService.Put<Response>(url, habitacionDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Delete(int id, string token)
        {
            string url = routesProvider.Habitacion.Delete + $"/{id}";

            var result = await httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
