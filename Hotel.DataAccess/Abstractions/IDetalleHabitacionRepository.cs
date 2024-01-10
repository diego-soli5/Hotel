using Hotel.Entities;
namespace Hotel.DataAccess.Abstractions
{
    public interface IDetalleHabitacionRepository 
    {
        public ThtDetallehabitacion GetByTnIdHabitacion(int id);

        public void Create(ThtDetallehabitacion detallehabitacion);

        public void Update(ThtDetallehabitacion detallehabitacion);
    }
}
