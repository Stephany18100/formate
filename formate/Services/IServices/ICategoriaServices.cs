using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface ICategoriaServices
    {
        //public Task<List<Categoria>> GetCategorias()
        public Task<Categoria> GetByIdCategoria(int id);
        public Task<Categoria> CreateCategoria(Categoria i);
        public Task<Categoria> UpdateCategoria(Categoria i);
        public bool DeleteCategoria(int id);

    }
}
