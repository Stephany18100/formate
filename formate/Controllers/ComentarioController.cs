using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formate.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioServices _cometarioservices;
        public ComentarioController(IComentarioServices cometarioservices)
        {
            _cometarioservices = cometarioservices;
        }

        [HttpGet]   
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _cometarioservices.GetComentarios());
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Comentario request)
        {
            var response = _cometarioservices.CreateComment(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id) //este busca el id 
        {
            var response = await _cometarioservices.GetByIdComentario(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]  //y este chambea
        public IActionResult Editar(Comentario request)
        {
            var response = _cometarioservices.UpdateComentario(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _cometarioservices.DeleteComentario(id);
            if(result == true)
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
