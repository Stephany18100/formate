using formate.Context;
using formate.Services.IServices;
using formate.Services.Service;
using formate.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace formate.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        private readonly ApplicationDbContext _context;

        public ClienteController(IClienteServices clienteServices, ApplicationDbContext context)
        {
            _clienteServices = clienteServices;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _clienteServices.GetCliente();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombrerol,
                Value = p.PkRoles.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cliente request)
        {
            var response = _clienteServices.CreateCliente(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _clienteServices.GetByIdCliente(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Cliente request)
        {
            var response = _clienteServices.UpdateCliente(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _clienteServices.DeleteCliente(id);
            if (result == true)
            {
                return Json(new { sucess = true });
            }
            else
            {
                return Json(new { sucess = false });
            }
        }

    }
}
