using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IClienteServices
    {
        public Task<List<Cliente>> GetCliente();
        public Task<Cliente> GetByIdCliente(int id);
        public Task<Cliente> CreateCliente(Cliente i);
        public Task<Cliente> UpdateCliente(Cliente i);
        public bool DeleteCliente(int id);

    }
}
