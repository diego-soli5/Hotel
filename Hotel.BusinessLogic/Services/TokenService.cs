using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.Options;
using Hotel.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotel.BusinessLogic.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthenticationOptions _options;

        public TokenService(IOptions<AuthenticationOptions> opciones)
        {
            _options = opciones.Value;
        }

        public (string, ClaimsPrincipal) GenerarJWT(ThtUsuario usuario)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var sigingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sigingCredentials);

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.TcNombre),
                new Claim(ClaimTypes.Email,usuario.TcCorreo)
            };

            //identity | principal
            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            //payload 
            var payload = new JwtPayload(
                _options.Issuer,
                _options.Audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(60));

            //signature
            var token = new JwtSecurityToken(header, payload);

            return (new JwtSecurityTokenHandler().WriteToken(token), principal);
        }
    }
}
