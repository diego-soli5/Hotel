using Hotel.BusinessLogic.DTO.Habitacion;

namespace Hotel.BusinessLogic.Abstractions
{
    public interface IHabitacionService
    {
        public HabitacionDTO GetById(int id);
        public IEnumerable<HabitacionDTO> GetAll();
        public bool Create(HabitacionCreateDTO habitacionCreateDTO);
        public bool Update(HabitacionDTO habitacionDTO, int id);
        public bool Delete(int id);
    }
}
