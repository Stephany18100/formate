using formate.Context;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace formate.Services.Service
{
    public class RolServices : IRolServices
    {

        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAll()
        {
            try
            {

                var response = await _context.Roles.ToListAsync();
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
