using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IClienteServices
    {
        public Task<List<Cliente>> GetAll();
        public Task<Cliente> Crear(Cliente i);
        public Task<Cliente> Editar(Cliente i);
        public  Task<Cliente> GetbyId(int id);
        bool EliminarCliente(int id);
    }
}
