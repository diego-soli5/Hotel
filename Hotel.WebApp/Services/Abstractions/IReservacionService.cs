using Hotel.WebApp.Models.HttpClienteService;
using Hotel.WebApp.Models.Reservacion;

namespace Hotel.WebApp.Services.Abstractions
{
    public interface IReservacionService
    {
        public Task<HttpRequestResult<ReservacionDTO>> GetById(int id, string token);
        public Task<HttpRequestResult<List<ReservacionDTO>>> GetAll(string token);
        public Task<HttpRequestResult<Response>> Create(ReservacionCreateDTO reservacionCreateDTO, string token);
        public Task<HttpRequestResult<Response>> Update(ReservacionDTO reservacionDTO, string token);
        public Task<HttpRequestResult<Response>> Delete(int id, string token);
    }
}
