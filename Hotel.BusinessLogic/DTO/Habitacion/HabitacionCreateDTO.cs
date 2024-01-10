namespace Hotel.BusinessLogic.DTO.Habitacion
{
    public class HabitacionCreateDTO
    {

        public string TcNombreHabitacion { get; set; } = null!;

        public string TcDscHabitacion { get; set; } = null!;

        public int TnIdTipoHabitacion { get; set; }

        public decimal TdPrecioXnoche { get; set; }

        //DetalleHabitacion
        public string TcTamanoHabitacion { get; set; } = null!;
        public string TcDscAmenidades { get; set; } = null!;
    }
}
