using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models.Usuario
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(50)]
        public string TcNombre { get; set; }
       
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(50)]
        public string TcNombreUsuario { get; set; }
        
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(50)]
        public string TcClave { get; set; }
        
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100)]
        public string TcCorreo { get; set; }
    }
}
