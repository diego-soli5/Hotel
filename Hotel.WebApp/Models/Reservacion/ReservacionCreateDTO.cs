using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.Reservacion
{
    public class ReservacionCreateDTO
    {
        public ReservacionCreateDTO() { }
        public ReservacionCreateDTO(int tnIdCliente, int tnIdHabitacion, DateTime tfFecInicio, DateTime tfFecFin)
        {
            TnIdCliente = tnIdCliente;
            TnIdHabitacion = tnIdHabitacion;
            TfFecInicio = tfFecInicio;
            TfFecFin = tfFecFin;
        }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [BindProperty(Name = $"{nameof(TnIdCliente)}")]
        public int TnIdCliente { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [BindProperty(Name = $"{nameof(TnIdHabitacion)}")]
        public int TnIdHabitacion { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [BindProperty(Name = $"Reservacion.{nameof(TfFecInicio)}")]
        public DateTime TfFecInicio { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [BindProperty(Name = $"Reservacion.{nameof(TfFecFin)}")]
        public DateTime TfFecFin { get; set; }
    }
}
