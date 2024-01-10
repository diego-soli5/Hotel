using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.Habitacion
{
    public class HabitacionCreateDTO
    {
        public HabitacionCreateDTO() { }

        public HabitacionCreateDTO(string tcNombreHabitacion, string tcDscHabitacion, int tnIdTipoHabitacion, decimal tdPrecioXnoche, string tcTamanoHabitacion, string tcDscAmenidades)
        {
            TcNombreHabitacion = tcNombreHabitacion;
            TcDscHabitacion = tcDscHabitacion;
            TnIdTipoHabitacion = tnIdTipoHabitacion;
            TdPrecioXnoche = tdPrecioXnoche;
            TcTamanoHabitacion = tcTamanoHabitacion;
            TcDscAmenidades = tcDscAmenidades;
        }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100)]
        [BindProperty(Name = $"Habitacion.{nameof(TcNombreHabitacion)}")]
        public string TcNombreHabitacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(150)]
        [BindProperty(Name = $"Habitacion.{nameof(TcDscHabitacion)}")]
        public string TcDscHabitacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [BindProperty(Name = $"{nameof(TnIdTipoHabitacion)}")]
        public int TnIdTipoHabitacion { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Range(1.0, 999999.99, ErrorMessage = "El valor debe estar entre 1.0 y 999999.99.")]
        [BindProperty(Name = $"Habitacion.{nameof(TdPrecioXnoche)}")]
        public decimal TdPrecioXnoche { get; set; }

        //DetalleHabitacion
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(60)]
        [BindProperty(Name = $"Habitacion.{nameof(TcTamanoHabitacion)}")]
        public string TcTamanoHabitacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(200)]
        [BindProperty(Name = $"Habitacion.{nameof(TcDscAmenidades)}")]
        public string TcDscAmenidades { get; set; } = null!;
    }
}
