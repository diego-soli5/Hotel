using Hotel.Entities;
using System.Security.Claims;

namespace Hotel.BusinessLogic.Abstractions
{
    public interface ITokenService
    {
        public (string, ClaimsPrincipal) GenerarJWT(ThtUsuario usuario);
    }
}
