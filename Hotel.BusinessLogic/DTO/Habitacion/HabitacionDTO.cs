namespace Hotel.BusinessLogic.DTO.Habitacion
{
    public class HabitacionDTO
    {
        public int Id { get; set; }

        public string TcNombreHabitacion { get; set; } = null!;

        public string TcDscHabitacion { get; set; } = null!;

        public int TnIdTipoHabitacion { get; set; }


        public decimal TdPrecioXnoche { get; set; }

        //TipoHabitacion
        public string TcNomTipoHabitacion { get; set; } = null!;

        //DetalleHabitacion
        public string TcTamanoHabitacion { get; set; } = null!;

        public string TcDscAmenidades { get; set; } = null!;
    }
}
