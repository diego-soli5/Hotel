using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.TipoHabitacion
{
    public class TipoHabitacionCreateDTO
    {
        public TipoHabitacionCreateDTO() { }    

        public TipoHabitacionCreateDTO(string tcNomTipoHabitacion)
        {
            TcNomTipoHabitacion = tcNomTipoHabitacion;
        }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100)]
        public string TcNomTipoHabitacion { get; set; } = null!;
    }
}
