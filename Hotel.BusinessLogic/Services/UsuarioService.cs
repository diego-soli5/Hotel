using AutoMapper;
using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.CustomExceptions;
using Hotel.BusinessLogic.DTO.Usuario;
using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.BusinessLogic.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenService tokenServicio;
        private readonly IPasswordService passwordService;
        private readonly IMapper mapper;

        public UsuarioService(IUnitOfWork unidadDeTrabajo,
                               ITokenService tokenServicio,
                               IPasswordService passwordService,
                               IMapper mapper)
        {
            unitOfWork = unidadDeTrabajo;
            this.tokenServicio = tokenServicio;
            this.passwordService = passwordService;
            this.mapper = mapper;
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarios = unitOfWork.Usuario.GetAll();

            var usuariosDTO = usuarios.ToList().Select(usuario => mapper.Map<UsuarioDTO>(usuario));

            return usuariosDTO;
        }
      
        public LoginResultDTO Login(string userName, string password)
        {
            var usuario = unitOfWork.Usuario.GetByUserName(userName);

            if (usuario == null)
            {
                throw new BusinessException("Nombre de usuario y/o contraseña incorrectos.", StatusCodes.Status401Unauthorized);
            }

            var result = passwordService.Check(usuario.TcClave, password);

            if (!result)
            {
                throw new BusinessException("Nombre de usuario y/o contraseña incorrectos.", StatusCodes.Status401Unauthorized);
            }

            var JWT = tokenServicio.GenerarJWT(usuario);

            return new LoginResultDTO(JWT.Item1, usuario.Id, usuario.TcNombre, usuario.TcCorreo);
        }

        public bool Register(RegisterDTO usuarioRegistrarDTO)
        {
            var usuario = mapper.Map<ThtUsuario>(usuarioRegistrarDTO);

            Validate(usuario);

            if (unitOfWork.Usuario.GetByUserName(usuario.TcNombreUsuario) != null)
            {
                throw new BusinessException("El nombre de usuario ya se encuentra en uso.", StatusCodes.Status400BadRequest);
            }

            if (unitOfWork.Usuario.GetByEmail(usuario.TcCorreo) != null)
            {
                throw new BusinessException("El correo electronico ya se encuentra en uso.", StatusCodes.Status400BadRequest);
            }

            usuario.TcClave = passwordService.Hash(usuario.TcClave);
            usuario.TbEstado = true;

            unitOfWork.Usuario.Create(usuario);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Delete(int id)
        {
            var usuario = unitOfWork.Usuario.GetById(id);

            if (usuario == null)
            {
                throw new BusinessException("El usuario no existe.", statusCode: StatusCodes.Status400BadRequest);
            }

            usuario.TbEstado = false;

            unitOfWork.Usuario.Update(usuario);

            bool result = unitOfWork.Save();

            return result;
        }

        private bool Validate(ThtUsuario usuario)
        {

            if (usuario.TcClave == null ||
               usuario.TcNombreUsuario == null ||
               usuario.TcNombre == null ||
               usuario.TcCorreo == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
