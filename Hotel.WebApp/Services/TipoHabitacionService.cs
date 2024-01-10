using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.TipoHabitacion;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;

namespace Hotel.WebApp.Services
{
    public class TipoHabitacionService : BaseService, ITipoHabitacionService
    {
        private readonly IHttpClientService httpClientService;
        private readonly ApiRoutesProvider routesProvider;

        public TipoHabitacionService(IHttpClientService httpClientService,
                                 ApiRoutesProvider routesProvider)
        {
            this.httpClientService = httpClientService;
            this.routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<TipoHabitacionDTO>> GetById(int id,string token)
        {
            string url = routesProvider.TipoHabitacion.GetById + $"/{id}";

            var result = await httpClientService.Get<TipoHabitacionDTO>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<List<TipoHabitacionDTO>>> GetAll(string token)
        {
            string url = routesProvider.TipoHabitacion.GetAll;

            var result = await httpClientService.Get<List<TipoHabitacionDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Create(TipoHabitacionCreateDTO tipoHabitacionCreateDTO, string token)
        {
            string url = routesProvider.TipoHabitacion.Create;

            var result = await httpClientService.Post<Response>(url, tipoHabitacionCreateDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Update(TipoHabitacionDTO tipoHabitacionDTO, string token)
        {
            string url = routesProvider.TipoHabitacion.Update + $"/{tipoHabitacionDTO.Id}";

            var result = await httpClientService.Put<Response>(url, tipoHabitacionDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Delete(int id, string token)
        {
            string url = routesProvider.TipoHabitacion.Delete + $"/{id}";

            var result = await httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
