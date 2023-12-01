using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace formate.Services.Service
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAll()
        {

            try
            {

                var res = await _context.Usuarios.ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<Usuario> Crear(Usuario i)
        {

            try
            {

                Usuario request = new Usuario()
                {
                    PkUsuario = 1,
                    NombreUsu = "Maria Jose",
                    Contrasena = "1234",
                    FkRol = 1
                };

                var response = await _context.Usuarios.AddAsync(request);
                _context.SaveChanges();

                return request;

            }
            catch (Exception)
            {

                throw;
            }

        }



        public async Task<Usuario> Editar(Usuario i)
        {
            try
            {

                Usuario usuario = _context.Usuarios.Find(i.PkUsuario);

                usuario.NombreUsu = i.NombreUsu;
                usuario.Contrasena = i.Contrasena;
                usuario.FkRol = i.FkRol;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<Usuario> GetbyId(int id)
        {
            try
            {
                var response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);

                return response;

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }



        public bool EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);


                if (usuario != null)
                {
                    var res = _context.Usuarios.Remove(usuario);
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