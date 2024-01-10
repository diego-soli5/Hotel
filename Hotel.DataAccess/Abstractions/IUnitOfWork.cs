namespace Hotel.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IClienteRepository Cliente { get; }
        IHabitacionRepository Habitacion { get; }
        IDetalleHabitacionRepository DetalleHabitacion { get; }
        IReservacionRepository Reservacion { get; }
        ITipoHabitacionRepository TipoHabitacion { get; }
        IUsuarioRepository Usuario { get; }
        
        bool Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

    }
}
