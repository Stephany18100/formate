using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetAll();
    }
}
