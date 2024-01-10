using Hotel.Entities;

namespace Hotel.DataAccess.Abstractions
{
    public interface IUsuarioRepository : IRepository<ThtUsuario>
    {
        public ThtUsuario GetByUserName(string userName);
        public ThtUsuario GetByEmail(string email);
    }
}
