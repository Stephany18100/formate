using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IUsuarioServices
    {
        public  Task<List<Usuario>> GetAll();
        public  Task<Usuario> Crear(Usuario i);

        public Task<Usuario> Editar(Usuario i);

        public Task<Usuario> GetbyId(int id);
    }
}
