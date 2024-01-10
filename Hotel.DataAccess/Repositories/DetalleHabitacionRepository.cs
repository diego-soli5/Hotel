using Hotel.DataAccess.Abstractions;
using Hotel.Entities;

namespace Hotel.DataAccess.Repositories
{
    public class DetalleHabitacionRepository : IDetalleHabitacionRepository
    {
        private readonly HotelContext context;

        public DetalleHabitacionRepository(HotelContext context) 
        {
            this.context = context;
        }

        public ThtDetallehabitacion GetByTnIdHabitacion(int id)
        {
            return context.ThtDetallehabitacion.FirstOrDefault(x => x.TnIdHabitacion == id);
        }

        public void Create(ThtDetallehabitacion detallehabitacion)
        {
            context.ThtDetallehabitacion.Add(detallehabitacion);
        }

        public void Update(ThtDetallehabitacion detallehabitacion)
        {
            context.ThtDetallehabitacion.Update(detallehabitacion);
        }
    }
}
