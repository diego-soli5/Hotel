using Hotel.Entities;

namespace Hotel.DataAccess.Abstractions
{
    public interface IReservacionRepository : IRepository<ThtReservacion>
    {
        IEnumerable<ThtReservacion> GetAllByTnIdHabitacion(ThtReservacion reservacion);
    }
}
