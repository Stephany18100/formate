using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace formate.Services.Service
{
    public class ClienteService : IClienteServices
    {

        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {

            try
            {

                var res = await _context.Clientes.ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<Cliente> Crear(Cliente i)
        {

            try
            {

                Cliente request = new Cliente()
                {
                    PkCliente = 1,
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Correo = i.Correo,
                    FkRol = 1

                };

                var response = await _context.Clientes.AddAsync(request);
                _context.SaveChanges();

                return request;

            }
            catch (Exception)
            {

                throw;
            }

        }



        public async Task<Cliente> Editar(Cliente i)
        {
            try
            {

                Cliente cliente = _context.Clientes.Find(i.PkCliente);

                cliente.Nombre = i.Nombre;
                cliente.Apellido = i.Apellido;
                cliente.Correo = i.Correo;
                cliente.FkRol = i.FkRol;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<Cliente> GetbyId(int id)
        {
            try
            {
                var response = await _context.Clientes.FirstOrDefaultAsync(x => x.PkCliente == id);

                return response;

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }


        public bool EliminarCliente(int id)
        {
            try
            {
                Cliente cliente = _context.Clientes.Find(id);


                if (cliente != null)
                {
                    var res = _context.Clientes.Remove(cliente);
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
