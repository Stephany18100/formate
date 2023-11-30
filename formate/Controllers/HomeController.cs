using formate.Context;
using formate.Models;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace formate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComentarioServices _comentarioServices; //solo esta de relleno?
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController>logger, IComentarioServices comentarioServices, ApplicationDbContext context)
        {
            _comentarioServices = comentarioServices;
            _logger = logger;
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult Inicio()
        {
            return View();
        }
      
        /*  [HttpGet]
          public async Task<IActionResult> Categorias()
          {
              var response = await _categoriasServices.GetCategorias
        return View(response)
          }*/

        [HttpGet] /*TAY CHAMBA*/
        public async Task<IActionResult> SobreNosotros() 
        {
            var response = await _comentarioServices.GetComentarios();
            return View(response);
        }

        /*FANNY CHAMBA*/
        [HttpGet]
        public async Task<IActionResult> InicioSesion()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
