using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.Cliente
{
    public class ClienteCreateDTO
    {
        public ClienteCreateDTO() { }

        public ClienteCreateDTO(string tcNombre, string tcAp1, string tcAp2, string tcNumTelefono, string tcCorreoElectronico)
        {
            TcNombre = tcNombre;
            TcAp1 = tcAp1;
            TcAp2 = tcAp2;
            TcNumTelefono = tcNumTelefono;
            TcCorreoElectronico = tcCorreoElectronico;
        }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(60)]
        public string TcNombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(60)]
        public string TcAp1 { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(60)]
        public string TcAp2 { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ingresar un número válido.")]
        public string TcNumTelefono { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100)]
        public string TcCorreoElectronico { get; set; } = null!;
    }
}
