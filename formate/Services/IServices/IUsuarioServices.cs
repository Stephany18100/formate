using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IUsuarioServices
    {
        public  Task<List<Usuario>> GetAll();
        public  Task<Usuario> Crear(Usuario i);

        public Task<Usuario> Editar(Usuario i);

        public Task<Usuario> GetbyId(int id);
<<<<<<< HEAD
=======

>>>>>>> 3ce4a15ebc9a49a45e8ada8785858236ebfc4c93
        bool EliminarUsuario(int id);
    }
}
