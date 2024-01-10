using AutoMapper;
using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.CustomExceptions;
using Hotel.BusinessLogic.DTO.Cliente;
using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.BusinessLogic.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClienteService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ClienteDTO GetById(int id)
        {
            var cliente = unitOfWork.Cliente.GetById(id);

            if (cliente == null)
            {
                throw new BusinessException("El cliente no existe.", StatusCodes.Status404NotFound);
            }

            var clienteDTO = mapper.Map<ClienteDTO>(cliente);

            return clienteDTO;
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = unitOfWork.Cliente.GetAll();

            var clientesDTO = clientes.Select(cliente => mapper.Map<ClienteDTO>(cliente));

            return clientesDTO;
        }

        public bool Create(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = mapper.Map<ThtCliente>(clienteCreateDTO);

            cliente.TbEstado = true;

            Validate(cliente);

            unitOfWork.Cliente.Create(cliente);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Update(ClienteDTO clienteDTO, int id)
        {
            var cliente = unitOfWork.Cliente.GetById(id);

            if (cliente == null)
            {
                throw new BusinessException("El cliente no existe.", StatusCodes.Status400BadRequest);
            }

            cliente.TcNombre = clienteDTO.TcNombre;
            cliente.TcAp1 = clienteDTO.TcAp1;
            cliente.TcAp2 = clienteDTO.TcAp2;
            cliente.TcCorreoElectronico = clienteDTO.TcCorreoElectronico;
            cliente.TcNumTelefono = clienteDTO.TcNumTelefono;

            Validate(cliente);

            unitOfWork.Cliente.Update(cliente);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Delete(int id)
        {
            var cliente = unitOfWork.Cliente.GetById(id, nameof(ThtCliente.ThtReservacion));

            if (cliente == null)
            {
                throw new BusinessException("El cliente no existe.", StatusCodes.Status400BadRequest);
            }

            if (cliente.ThtReservacion != null)
            {
                if (cliente.ThtReservacion.Where(x => x.TbEstado).Count() > 0)
                {
                    throw new BusinessException("No se puede eliminar porque el cliente tiene reservaciones activas.", StatusCodes.Status400BadRequest);
                }
            }

            cliente.TbEstado = false;

            unitOfWork.Cliente.Update(cliente);

            bool result = unitOfWork.Save();

            return result;
        }

        private bool Validate(ThtCliente cliente)
        {

            if (cliente.TcNombre == null ||
               cliente.TcAp1 == null ||
               cliente.TcAp2 == null ||
               cliente.TcNumTelefono == null ||
               cliente.TcCorreoElectronico == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
