namespace Hotel.BusinessLogic.DTO.Reservacion
{
    public class ReservacionCreateDTO
    {
        public int TnIdCliente { get; set; }

        public int TnIdHabitacion { get; set; }

        public DateTime TfFecInicio { get; set; }

        public DateTime TfFecFin { get; set; }
    }
}
