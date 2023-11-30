using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace formate.Services.Service
{
    public class ComentarioService : IComentarioServices
    {
        private readonly ApplicationDbContext _context;
        public ComentarioService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Comentario>> GetComentarios()
        {
            try
            {
                return await _context.Comentarios.ToListAsync();
               // var response = await _context.Comentarios.Include(y => y.PkComentario).ToListAsync();
               // return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Comentario> GetByIdComentario(int id)
        {
            try
            {
                Comentario response = await _context.Comentarios.FirstOrDefaultAsync(x => x.PkComentario == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Comentario> CreateComment(Comentario i)
        {
            try
            {
                Comentario request = new Comentario()
                {
                    PkComentario = i.PkComentario,
                    Texto = i.Texto,
                    FkCliente = i.FkCliente
                };

                var response = await _context.Comentarios.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Comentario> UpdateComentario(Comentario i)
        {
            try
            {
                Comentario comentario = _context.Comentarios.Find(i.PkComentario);

                comentario.PkComentario = i.PkComentario;
                comentario.Texto = i.Texto;
                comentario.Clientes = i.Clientes;

                _context.Entry(comentario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return comentario;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public bool DeleteComentario(int id)
        {
            try
            {
                Comentario comentario = _context.Comentarios.Find(id);

                if (comentario != null)
                {
                    var response = _context.Comentarios.Remove(comentario);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }
    }
}
