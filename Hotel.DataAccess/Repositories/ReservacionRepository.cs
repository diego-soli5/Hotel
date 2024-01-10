using Hotel.DataAccess.Abstractions;
using Hotel.Entities;

namespace Hotel.DataAccess.Repositories
{
    public class ReservacionRepository : Repository<ThtReservacion>, IReservacionRepository
    {
        private readonly HotelContext context;

        public ReservacionRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<ThtReservacion> GetAllByTnIdHabitacion(ThtReservacion reservacion)
        {
#pragma warning disable CS8603 
            return context.ThtReservacion.Where(r => r.TbEstado &&
                                                     r.TnIdHabitacion == reservacion.TnIdHabitacion)
                                            .AsEnumerable();
#pragma warning restore CS8603 
        }
    }
}
