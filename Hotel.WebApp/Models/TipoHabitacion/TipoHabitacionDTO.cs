using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.TipoHabitacion
{
    public class TipoHabitacionDTO
    {
        public TipoHabitacionDTO()
        {
        }

        public TipoHabitacionDTO(int id, string tcNomTipoHabitacion)
        {
            Id = id;
            TcNomTipoHabitacion = tcNomTipoHabitacion;
        }

        public int Id { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100)]
        public string TcNomTipoHabitacion { get; set; } = null!;
    }
}
