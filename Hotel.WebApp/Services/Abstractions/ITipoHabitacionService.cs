using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.TipoHabitacion;

namespace Hotel.WebApp.Services.Abstractions
{
    public interface ITipoHabitacionService
    {
        public Task<HttpRequestResult<TipoHabitacionDTO>> GetById(int id, string token);
        public Task<HttpRequestResult<List<TipoHabitacionDTO>>> GetAll(string token);
        public Task<HttpRequestResult<Response>> Create(TipoHabitacionCreateDTO tipoHabitacionCreateDTO, string token);
        public Task<HttpRequestResult<Response>> Update(TipoHabitacionDTO tipoHabitacionDTO, string token);
        public Task<HttpRequestResult<Response>> Delete(int id, string token);
    }
}
