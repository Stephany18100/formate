using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IClienteServices
    {
<<<<<<< HEAD
        public Task<List<Cliente>> GetCliente();
        public Task<Cliente> GetByIdCliente(int id);
        public Task<Cliente> CreateCliente(Cliente i);
        public Task<Cliente> UpdateCliente(Cliente i);
        public bool DeleteCliente(int id);

=======
        public Task<List<Cliente>> GetAll();
        public Task<Cliente> Crear(Cliente i);
        public Task<Cliente> Editar(Cliente i);
        public  Task<Cliente> GetbyId(int id);
        bool EliminarCliente(int id);
>>>>>>> 3ce4a15ebc9a49a45e8ada8785858236ebfc4c93
    }
}
