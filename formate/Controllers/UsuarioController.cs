using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using formate.Models.Entities;
using formate.Services.IServices;
using formate.Services.Service;
using Microsoft.EntityFrameworkCore;
using formate.Context;

namespace formate.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly ApplicationDbContext _context;

        public UsuarioController(IUsuarioServices usuarioService, ApplicationDbContext context)
        {
            _usuarioServices = usuarioService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _usuarioServices.GetAll();
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
        public IActionResult Crear(Usuario usuario)
        {
            var response = _usuarioServices.Crear(usuario);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _usuarioServices.GetbyId(id);

            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombrerol,
                Value = p.PkRoles.ToString()
            });

            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var response = _usuarioServices.Editar(usuario);
            return RedirectToAction(nameof(Index));
        }
    }
}
