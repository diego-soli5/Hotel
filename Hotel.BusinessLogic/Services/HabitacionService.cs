using AutoMapper;
using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.CustomExceptions;
using Hotel.BusinessLogic.DTO.Habitacion;
using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.BusinessLogic.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HabitacionService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public HabitacionDTO GetById(int id)
        {
            var habitacion = unitOfWork.Habitacion.GetById(id, $"{nameof(ThtHabitacion.TnIdTipoHabitacionNavigation)},{nameof(ThtHabitacion.ThtDetallehabitacionNavigation)}");

            if (habitacion == null)
            {
                throw new BusinessException("La habitación no existe.", StatusCodes.Status404NotFound);
            }

            var habitacionDTO = mapper.Map<HabitacionDTO>(habitacion);

            return habitacionDTO;
        }

        public IEnumerable<HabitacionDTO> GetAll()
        {
            var habitaciones = unitOfWork.Habitacion.GetAll($"{nameof(ThtHabitacion.TnIdTipoHabitacionNavigation)},{nameof(ThtHabitacion.ThtDetallehabitacionNavigation)}");

            var habitacionesDTO = habitaciones.Select(habitacion => mapper.Map<HabitacionDTO>(habitacion));

            return habitacionesDTO;
        }

        public bool Create(HabitacionCreateDTO habitacionCreateDTO)
        {
            var habitacion = mapper.Map<ThtHabitacion>(habitacionCreateDTO);

            string entity = ValidateForeignKeys(habitacion);

            if (entity != null)
            {
                throw new BusinessException($"{entity} no existe.", StatusCodes.Status400BadRequest);
            }

            habitacion.TbEstado = true;

            Validate(habitacion);

            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.Habitacion.Create(habitacion);

                bool result = unitOfWork.Save();

                var detalleHabitacion = new ThtDetallehabitacion();
                detalleHabitacion.TnIdHabitacion = habitacion.Id;
                detalleHabitacion.TcTamanoHabitacion = habitacionCreateDTO.TcTamanoHabitacion;
                detalleHabitacion.TcDscAmenidades = habitacionCreateDTO.TcDscAmenidades;

                if (detalleHabitacion.TcDscAmenidades == null ||
                    detalleHabitacion.TcTamanoHabitacion == null)
                {
                    unitOfWork.RollbackTransaction();

                    throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
                }

                unitOfWork.DetalleHabitacion.Create(detalleHabitacion);

                unitOfWork.Save();

                unitOfWork.CommitTransaction();

                return result;
            }
            catch (Exception)
            {
                unitOfWork.RollbackTransaction();

                throw;
            }
        }

        public bool Update(HabitacionDTO habitacionDTO, int id)
        {
            var habitacion = unitOfWork.Habitacion.GetById(id);

            if (habitacion == null)
            {
                throw new BusinessException("La habitación no existe.", StatusCodes.Status400BadRequest);
            }

            habitacion.TcNombreHabitacion = habitacionDTO.TcNombreHabitacion;
            habitacion.TcDscHabitacion = habitacionDTO.TcDscHabitacion;
            habitacion.TnIdTipoHabitacion = habitacionDTO.TnIdTipoHabitacion;
            habitacion.TdPrecioXnoche = habitacionDTO.TdPrecioXnoche;

            string entity = ValidateForeignKeys(habitacion);

            if (entity != null)
            {
                throw new BusinessException($"{entity} no existe.", StatusCodes.Status400BadRequest);
            }

            Validate(habitacion);

            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.Habitacion.Update(habitacion);

                bool result = unitOfWork.Save();

                var detalleHabitacion = unitOfWork.DetalleHabitacion.GetByTnIdHabitacion(habitacion.Id);

                detalleHabitacion.TcTamanoHabitacion = habitacionDTO.TcTamanoHabitacion;
                detalleHabitacion.TcDscAmenidades = habitacionDTO.TcDscAmenidades;

                if (detalleHabitacion.TcDscAmenidades == null ||
                    detalleHabitacion.TcTamanoHabitacion == null)
                {
                    unitOfWork.RollbackTransaction();

                    throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
                }

                unitOfWork.DetalleHabitacion.Update(detalleHabitacion);

                unitOfWork.Save();

                unitOfWork.CommitTransaction();

                return result;
            }
            catch (Exception)
            {
                unitOfWork.RollbackTransaction();
                
                throw;
            }
        }

        public bool Delete(int id)
        {
            var habitacion = unitOfWork.Habitacion.GetById(id);

            if (habitacion == null)
            {
                throw new BusinessException("La habitación no existe.", StatusCodes.Status400BadRequest);
            }

            habitacion.TbEstado = false;

            unitOfWork.Habitacion.Update(habitacion);

            bool result = unitOfWork.Save();

            return result;
        }

        private string ValidateForeignKeys(ThtHabitacion habitacion)
        {
            if (unitOfWork.TipoHabitacion.GetById(habitacion.TnIdTipoHabitacion) == null)
            {
                return "Tipo de habitación";
            }

            return null;
        }

        private bool Validate(ThtHabitacion habitacion)
        {
            if (habitacion.TcNombreHabitacion == null ||
                habitacion.TcDscHabitacion == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            if (habitacion.TdPrecioXnoche < 0)
            {
                throw new BusinessException("El precio debe ser mayor a 0.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
