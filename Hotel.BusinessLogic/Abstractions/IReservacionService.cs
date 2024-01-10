using Hotel.BusinessLogic.DTO.Reservacion;

namespace Hotel.BusinessLogic.Abstractions
{
    public interface IReservacionService
    {
        public ReservacionDTO GetById(int id);
        public IEnumerable<ReservacionDTO> GetAll();
        public bool Create(ReservacionCreateDTO reservacionCreateDTO);
        public bool Update(ReservacionDTO reservacionDTO, int id);
        public bool Delete(int id);
    }
}
