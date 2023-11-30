using formate.Models.Entities;

namespace formate.Services.IServices
{
    public interface IComentarioServices
    {
        public Task<List<Comentario>> GetComentarios();
        public Task<Comentario> GetByIdComentario(int id);
        public Task<Comentario> CreateComment(Comentario i);
        public Task<Comentario> UpdateComentario(Comentario i);
        public bool DeleteComentario(int id);


    }
}
