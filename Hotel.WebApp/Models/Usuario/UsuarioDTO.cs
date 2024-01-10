namespace Hotel.WebApp.Models.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string TcNombre { get; set; } = null!;
        public string TcNombreUsuario { get; set; } = null!;
        public string TcCorreo { get; set; } = null!;
    }
}
