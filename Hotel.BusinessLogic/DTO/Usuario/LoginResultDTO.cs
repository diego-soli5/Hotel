namespace Hotel.BusinessLogic.DTO.Usuario
{
    public class LoginResultDTO
    {
        public LoginResultDTO() { }

        public LoginResultDTO(string token, int id, string tcNombre, string tcCorreo)
        {
            Id = id;
            Token = token;
            TcNombre = tcNombre;
            TcCorreo = tcCorreo;
        }

        public int Id { get; }
        public string Token { get; }
        public string TcNombre { get; }
        public string TcCorreo { get; }
    }
}
