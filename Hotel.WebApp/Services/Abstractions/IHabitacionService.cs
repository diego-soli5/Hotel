using Hotel.WebApp.Models.Habitacion;
using Hotel.WebApp.Models.HttpClienteService;

namespace Hotel.WebApp.Services.Abstractions
{
    public interface IHabitacionService
    {
        public Task<HttpRequestResult<HabitacionDTO>> GetById(int id, string token);
        public Task<HttpRequestResult<List<HabitacionDTO>>> GetAll(string token);
        public Task<HttpRequestResult<Response>> Create(HabitacionCreateDTO habitacionCreateDTO, string token);
        public Task<HttpRequestResult<Response>> Update(HabitacionDTO habitacionDTO, string token);
        public Task<HttpRequestResult<Response>> Delete(int id, string token);
    }
}
