using Hotel.DataAccess.Abstractions;
using Hotel.Entities;

namespace Hotel.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<ThtUsuario>, IUsuarioRepository
    {
        private readonly HotelContext context;

        public UsuarioRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public ThtUsuario GetByUserName(string userName)
        {
            return context.ThtUsuario.FirstOrDefault(u => u.TcNombreUsuario == userName && u.TbEstado);
        }

        public ThtUsuario GetByEmail(string email)
        {
            return context.ThtUsuario.FirstOrDefault(u => u.TcCorreo == email && u.TbEstado);
        }
    }
}
