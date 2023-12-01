using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace formate.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServices _articuloServices;
        public CategoriaController(ICategoriaServices articuloServices)
        {
            _articuloServices = articuloServices;
        }


        /*   [HttpGet]
           public async Task<IActionResult> Index()
           {
               try
               {
                   //Modo de pensar junior xd
                   //var response = await _articuloServices.GetArticulos();

                   //return View(response);

                   //Modo de pensar Senior profa majo
                   return View(await _articuloServices.GetCategoria());


               }
               catch (Exception ex)
               {

                   throw new Exception("Succedio un error" + ex.Message);
               }

           }*/

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Categoria request)
        {
            var response = _articuloServices.CreateCategoria(request);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var response = await _articuloServices.GetByIdCategoria(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Categoria request)
        {
            var response = _articuloServices.UpdateCategoria(request);


            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _articuloServices.DeleteCategoria(id);
            if (result == true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }

        }
    }
}
