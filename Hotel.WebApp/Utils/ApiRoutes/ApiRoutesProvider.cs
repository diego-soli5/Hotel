namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class ApiRoutesProvider
    {
        private readonly ClienteRoutes clienteRoutes;
        private readonly ReservacionRoutes reservacionRoutes;
        private readonly HabitacionRoutes habitacionRoutes;
        private readonly TipoHabitacionRoutes tipoHabitacionRoutes;
        private readonly UsuarioRoutes usuarioRoutes;

        public ApiRoutesProvider(ClienteRoutes clienteRoutes,
                                 ReservacionRoutes reservacionRoutes,
                                 HabitacionRoutes habitacionRoutes,
                                 TipoHabitacionRoutes tipoHabitacionRoutes,
                                 UsuarioRoutes usuarioRoutes)
        {
            this.clienteRoutes = clienteRoutes;
            this.reservacionRoutes = reservacionRoutes;
            this.habitacionRoutes = habitacionRoutes;
            this.tipoHabitacionRoutes = tipoHabitacionRoutes;
            this.usuarioRoutes = usuarioRoutes;
        }

        public ClienteRoutes Cliente => clienteRoutes;
        public ReservacionRoutes Reservacion => reservacionRoutes;
        public HabitacionRoutes Habitacion => habitacionRoutes;
        public TipoHabitacionRoutes TipoHabitacion => tipoHabitacionRoutes;
        public UsuarioRoutes Usuario => usuarioRoutes;
    }
}
