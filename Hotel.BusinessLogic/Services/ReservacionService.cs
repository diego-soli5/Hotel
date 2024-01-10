using AutoMapper;
using Hotel.BusinessLogic.Abstractions;
using Hotel.BusinessLogic.CustomExceptions;
using Hotel.BusinessLogic.DTO.Reservacion;
using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.AspNetCore.Http;

namespace Hotel.BusinessLogic.Services
{
    public class ReservacionService : IReservacionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReservacionService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ReservacionDTO GetById(int id)
        {
            var reservacion = unitOfWork.Reservacion.GetById(id, $"{nameof(ThtReservacion.TnIdHabitacionNavigation)},{nameof(ThtReservacion.TnIdClienteNavigation)}");

            if (reservacion == null)
            {
                throw new BusinessException("La reservacion no existe.", StatusCodes.Status404NotFound);
            }

            var reservacionDTO = mapper.Map<ReservacionDTO>(reservacion);

            return reservacionDTO;
        }

        public IEnumerable<ReservacionDTO> GetAll()
        {
            var reservaciones = unitOfWork.Reservacion.GetAll($"{nameof(ThtReservacion.TnIdHabitacionNavigation)},{nameof(ThtReservacion.TnIdClienteNavigation)}");

            var reservacionsDTO = reservaciones.Select(reservacion => mapper.Map<ReservacionDTO>(reservacion));

            return reservacionsDTO;
        }

        public bool Create(ReservacionCreateDTO reservacionCreateDTO)
        {
            var reservacion = mapper.Map<ThtReservacion>(reservacionCreateDTO);

            string entity = ValidateForeignKeys(reservacion);

            if (entity != null)
            {
                throw new BusinessException($"{entity} no existe.", StatusCodes.Status400BadRequest);
            }

            reservacion.TbEstado = true;

            Validate(reservacion);

            ValidateIfAlreadyReserved(reservacion);

            unitOfWork.Reservacion.Create(reservacion);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Update(ReservacionDTO reservacionDTO, int id)
        {
            var reservacion = unitOfWork.Reservacion.GetById(id);

            if (reservacion == null)
            {
                throw new BusinessException("La reservacion no existe.", StatusCodes.Status400BadRequest);
            }

            reservacion.TnIdCliente = reservacionDTO.TnIdCliente;
            reservacion.TnIdHabitacion = reservacionDTO.TnIdHabitacion;
            reservacion.TfFecInicio = reservacionDTO.TfFecInicio;
            reservacion.TfFecFin = reservacionDTO.TfFecFin;

            string entity = ValidateForeignKeys(reservacion);

            if (entity != null)
            {
                throw new BusinessException($"{entity} no existe.", StatusCodes.Status400BadRequest);
            }

            Validate(reservacion);

            ValidateIfAlreadyReserved(reservacion);

            unitOfWork.Reservacion.Update(reservacion);

            bool result = unitOfWork.Save();

            return result;
        }

        public bool Delete(int id)
        {
            var reservacion = unitOfWork.Reservacion.GetById(id);

            if (reservacion == null)
            {
                throw new BusinessException("La reservacion no existe.", StatusCodes.Status400BadRequest);
            }

            reservacion.TbEstado = false;

            unitOfWork.Reservacion.Update(reservacion);

            bool result = unitOfWork.Save();

            return result;
        }

        private void ValidateIfAlreadyReserved(ThtReservacion reservacion)
        {
            var reservacionesDb = unitOfWork.Reservacion.GetAllByTnIdHabitacion(reservacion)
                                                        .Where(x => x.Id != reservacion.Id);
            
            foreach (var reservationDb in reservacionesDb)
            {
                if (reservacion.TfFecInicio >= reservationDb.TfFecInicio && reservacion.TfFecInicio <= reservationDb.TfFecFin)
                {
                    throw new BusinessException("No se puede reservar, ya hay una reservación que coincide con la habitación y rango de fechas indicado.", StatusCodes.Status400BadRequest);
                }

                if (reservacion.TfFecInicio <= reservationDb.TfFecInicio && reservacion.TfFecFin >= reservationDb.TfFecInicio)
                {
                    throw new BusinessException("No se puede reservar, ya hay una reservación que coincide con la habitación y rango de fechas indicado.", StatusCodes.Status400BadRequest);
                }
            }
        }

        private string ValidateForeignKeys(ThtReservacion reservacion)
        {
            if (unitOfWork.Cliente.GetById(reservacion.TnIdCliente) == null)
            {
                return "Cliente";
            }

            if (unitOfWork.Habitacion.GetById(reservacion.TnIdHabitacion) == null)
            {
                return "Habitación";
            }


            return null;
        }

        private bool Validate(ThtReservacion reservacion)
        {
            if (reservacion.TfFecInicio.Date > reservacion.TfFecFin.Date)
            {
                throw new BusinessException("La fecha de inicio no puede ser mayor a la fecha final.", StatusCodes.Status400BadRequest);
            }

            if (reservacion.TfFecInicio.Date <= DateTime.Now.AddDays(-1).Date)
            {
                throw new BusinessException("La fecha de inicio no puede ser menor a la actual.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
