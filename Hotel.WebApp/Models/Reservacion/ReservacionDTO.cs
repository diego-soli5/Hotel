using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.Reservacion
{
    public class ReservacionDTO
    {
        public ReservacionDTO() { }
        public ReservacionDTO(int id, int tnIdCliente, int tnIdHabitacion, DateTime tfFecInicio, DateTime tfFecFin, string tcNombre, string tcNombreHabitacion)
        {
            Id = id;
            TnIdCliente = tnIdCliente;
            TnIdHabitacion = tnIdHabitacion;
            TfFecInicio = tfFecInicio;
            TfFecFin = tfFecFin;
            TcNombre = tcNombre;
            TcNombreHabitacion = tcNombreHabitacion;
        }

        [BindProperty(Name = $"Reservacion.{nameof(Id)}")]
        public int Id { get; set; }

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


        //Cliente
        [BindProperty(Name = $"Reservacion.{nameof(TcNombre)}")]
        public string TcNombre { get; set; } = null!;

        //Habitacion
        [BindProperty(Name = $"Reservacion.{nameof(TcNombreHabitacion)}")]
        public string TcNombreHabitacion { get; set; } = null!;
    }
}
