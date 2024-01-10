using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.Usuario;
using Hotel.WebApp.Services.Abstractions;
using Hotel.WebApp.Utils.ApiRoutes;

namespace Hotel.WebApp.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IHttpClientService httpClientService;
        private readonly ApiRoutesProvider routesProvider;

        public UsuarioService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            this.httpClientService = httpClientService;
            this.routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult> Delete(int id, string token)
        {
            string url = routesProvider.Usuario.Delete + $"/{id}";

            var result = await httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<List<UsuarioDTO>>> GetAll(string token)
        {
            string url = routesProvider.Usuario.GetAll;

            var result = await httpClientService.Get<List<UsuarioDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<LoginResultDTO>> Login(string userName, string password)
        {
            string url = routesProvider.Usuario.Login;

            var result = await httpClientService.Post<LoginResultDTO>(url, new LoginRequestDTO { UserName = userName, Password = password });

            CheckRequestResult(result, false);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Register(RegisterDTO registerDTO, string token)
        {
            string url = routesProvider.Usuario.Register;

            var result = await httpClientService.Post<Response>(url, registerDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
