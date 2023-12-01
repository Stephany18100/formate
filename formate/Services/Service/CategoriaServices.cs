using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace formate.Services.Service
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ApplicationDbContext _context;
        public CategoriaServices(ApplicationDbContext context)
        {
            _context = context;
        }

     /*   public async Task<List<Categoria>> GetCategorias()
        {
            try
            {
                var response = await _context.Database.GetDbConnection().QueryAsync<Categoria>("spGetCliente", new { }, commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }*/

        public async Task<Categoria> GetByIdCategoria(int id)
        {
            try
            {
                Categoria response = await _context.Categorias.FirstOrDefaultAsync(x => x.PkCategoria == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Categoria> CreateCategoria(Categoria i)
        {
            try
            {
                Categoria request = new Categoria()
                {
                    Titulo = i.Titulo,
                    Descripcion = i.Descripcion
                };

                var response = await _context.Categorias.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Categoria> UpdateCategoria(Categoria i)
        {
            try
            {
                Categoria categoria = _context.Categorias.Find(i.PkCategoria);
                categoria.Titulo = i.Titulo;
                categoria.Descripcion = i.Descripcion;

                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public bool DeleteCategoria(int id)
        {
            try
            {
                Categoria categoria = _context.Categorias.Find(id);


                if (categoria != null)
                {
                    var res = _context.Categorias.Remove(categoria);
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
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
    }
}
