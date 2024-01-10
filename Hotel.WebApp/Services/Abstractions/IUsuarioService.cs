using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.Usuario;

namespace Hotel.WebApp.Services.Abstractions
{
    public interface IUsuarioService
    {
        public Task<HttpRequestResult<List<UsuarioDTO>>> GetAll(string token);
        public Task<HttpRequestResult<LoginResultDTO>> Login(string userName, string password);
        public Task<HttpRequestResult<Response>> Register(RegisterDTO registerDTO, string token);
        public Task<HttpRequestResult> Delete(int id, string token);
    }
}
