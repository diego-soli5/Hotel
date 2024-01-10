using Hotel.BusinessLogic.DTO.Cliente;

namespace Hotel.BusinessLogic.Abstractions
{
    public interface IClienteService
    {
        public ClienteDTO GetById(int id);

        public IEnumerable<ClienteDTO> GetAll();

        public bool Create(ClienteCreateDTO clienteCreateDTO);

        public bool Update(ClienteDTO clienteDTO, int id);

        public bool Delete(int id);
    }
}
