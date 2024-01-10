using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.Reservacion;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;

namespace Hotel.WebApp.Services
{
    public class ReservacionService : BaseService, IReservacionService
    {
        private readonly IHttpClientService httpClientService;
        private readonly ApiRoutesProvider routesProvider;

        public ReservacionService(IHttpClientService httpClientService,
                                 ApiRoutesProvider routesProvider)
        {
            this.httpClientService = httpClientService;
            this.routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<ReservacionDTO>> GetById(int id, string token)
        {
            string url = routesProvider.Reservacion.GetById + $"/{id}";

            var result = await httpClientService.Get<ReservacionDTO>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<List<ReservacionDTO>>> GetAll(string token)
        {
            string url = routesProvider.Reservacion.GetAll;

            var result = await httpClientService.Get<List<ReservacionDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Create(ReservacionCreateDTO reservacionCreateDTO, string token)
        {
            string url = routesProvider.Reservacion.Create;

            var result = await httpClientService.Post<Response>(url, reservacionCreateDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Update(ReservacionDTO reservacionDTO, string token)
        {
            string url = routesProvider.Reservacion.Update + $"/{reservacionDTO.Id}";

            var result = await httpClientService.Put<Response>(url, reservacionDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Delete(int id, string token)
        {
            string url = routesProvider.Reservacion.Delete + $"/{id}";

            var result = await httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
