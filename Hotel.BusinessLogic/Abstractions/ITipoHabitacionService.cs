using Hotel.BusinessLogic.DTO.TipoHabitacion;

namespace Hotel.BusinessLogic.Abstractions
{
    public interface ITipoHabitacionService
    {
        public TipoHabitacionDTO GetById(int id);
        public IEnumerable<TipoHabitacionDTO> GetAll();
        public bool Create(TipoHabitacionCreateDTO tipohabitacionCrearDTO);
        public bool Update(TipoHabitacionDTO tipohabitacionDTO, int id);
        public bool Delete(int id);
    }
}
