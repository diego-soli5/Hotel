using Hotel.DataAccess.Abstractions;

namespace Hotel.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext context;

        public UnitOfWork(HotelContext context)
        {
            this.context = context;
        }

        public IClienteRepository Cliente => new ClienteRepository(context);
        public IHabitacionRepository Habitacion => new HabitacionRepository(context);
        public IDetalleHabitacionRepository DetalleHabitacion => new DetalleHabitacionRepository(context);
        public IReservacionRepository Reservacion => new ReservacionRepository(context);
        public ITipoHabitacionRepository TipoHabitacion => new TipoHabitacionRepository(context);
        public IUsuarioRepository Usuario => new UsuarioRepository(context);

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            context.Database.RollbackTransaction();
        }

        public bool Save()
        {
            return context.SaveChanges() > 0;
        }
    }
}
