using AutoMapper;
using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.CustomExceptions;
using Hotel.BusinessLogic.DTO.TipoHabitacion;
using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.BusinessLogic.Services
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TipoHabitacionService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TipoHabitacionDTO GetById(int id)
        {
            var tipohabitacion = unitOfWork.TipoHabitacion.GetById(id);

            if (tipohabitacion == null)
            {
                throw new BusinessException("El tipo de habitación no existe.", StatusCodes.Status404NotFound);
            }

            var tipohabitacionDTO = mapper.Map<TipoHabitacionDTO>(tipohabitacion);

            return tipohabitacionDTO;
        }

        public IEnumerable<TipoHabitacionDTO> GetAll()
        {
            var tipohabitaciones = unitOfWork.TipoHabitacion.GetAll();

            var tipohabitacionDTO = tipohabitaciones.Select(tipohabitacion => mapper.Map<TipoHabitacionDTO>(tipohabitacion));

            return tipohabitacionDTO;
        }

        public bool Create(TipoHabitacionCreateDTO tipohabitacionCrearDTO)
        {
            var tipohabitacion = mapper.Map<ThtTipohabitacion>(tipohabitacionCrearDTO);

            tipohabitacion.TbEstado = true;

            Validate(tipohabitacion);

            unitOfWork.TipoHabitacion.Create(tipohabitacion);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Update(TipoHabitacionDTO tipohabitacionDTO, int id)
        {
            var tipohabitacion = unitOfWork.TipoHabitacion.GetById(id);

            if (tipohabitacion == null)
            {
                throw new BusinessException("El tipo de habitación no existe.", StatusCodes.Status400BadRequest);
            }

            tipohabitacion.TcNomTipoHabitacion = tipohabitacionDTO.TcNomTipoHabitacion;

            Validate(tipohabitacion);

            unitOfWork.TipoHabitacion.Update(tipohabitacion);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Delete(int id)
        {
            var tipohabitacion = unitOfWork.TipoHabitacion.GetById(id, nameof(ThtTipohabitacion.ThtHabitacions));

            if (tipohabitacion == null)
            {
                throw new BusinessException("El tipo de habitación no existe.", StatusCodes.Status400BadRequest);
            }

            if (tipohabitacion.ThtHabitacions != null)
            {
                if (tipohabitacion.ThtHabitacions.Where(x => x.TbEstado).Any())
                {
                    throw new BusinessException("No se puede eliminar porque el tipo de habitación tiene habitaciones activas asociadas.", StatusCodes.Status400BadRequest);
                }
            }

            tipohabitacion.TbEstado = false;

            unitOfWork.TipoHabitacion.Update(tipohabitacion);

            bool result = unitOfWork.Save();

            return result;
        }

        private bool Validate(ThtTipohabitacion tipohabitacion)
        {

            if (tipohabitacion.TcNomTipoHabitacion == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
