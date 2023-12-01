using Microsoft.EntityFrameworkCore;
using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;

namespace formate.Services.Service
{
    public class ClienteServices : IClienteServices
    {
        private readonly ApplicationDbContext _context;
        public ClienteServices(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetCliente()
        {
            try
            {
                var res = await _context.Clientes.Include(x => x.Roles).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Cliente> GetByIdCliente(int id)
        {
            try
            {

                Cliente response = await _context.Clientes.FirstOrDefaultAsync(x => x.PkCliente == id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Cliente> CreateCliente(Cliente i)
        {
            try
            {
                Cliente request = new Cliente()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Correo = i.Correo,
                    FkRol = i.FkRol
                };
                var response = await _context.Clientes.AddAsync(request);
                _context.SaveChanges();
                return request;

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Cliente> UpdateCliente(Cliente i)
        {
            try
            {
                Cliente cliente = _context.Clientes.Find(i.PkCliente);

                cliente.Nombre = i.Nombre;
                cliente.Apellido = i.Apellido;
                cliente.Correo = i.Correo;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }

        }
        

        public bool DeleteCliente(int id)
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
