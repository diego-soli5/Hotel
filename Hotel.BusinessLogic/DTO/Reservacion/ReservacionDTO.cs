namespace Hotel.BusinessLogic.DTO.Reservacion
{
    public class ReservacionDTO
    {
        public int Id { get; set; }

        public int TnIdCliente { get; set; }

        public int TnIdHabitacion { get; set; }

        public DateTime TfFecInicio { get; set; }

        public DateTime TfFecFin { get; set; }


        //Cliente
        public string TcNombre { get; set; } = null!;
        
        //Habitacion
        public string TcNombreHabitacion { get; set; } = null!;
    }
}
