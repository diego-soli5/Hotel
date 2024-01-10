using Hotel.BusinessLogic.DTO.Usuario;


namespace Hotel.BusinessLogic.Abstractions
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDTO> GetAll();
        LoginResultDTO Login(string userName, string password);
        bool Register(RegisterDTO usuarioRegistrarDTO);
        bool Delete(int id);
    }
}
