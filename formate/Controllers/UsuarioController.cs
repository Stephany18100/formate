using System.Collections.Generic;
using System.Threading.Tasks;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace formate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            try
            {
                var usuarios = await _usuarioServices.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Usuario>> Crear([FromBody] Usuario usuario)
        {
            try
            {
                var nuevoUsuario = await _usuarioServices.Crear(usuario);
                return Ok(nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<Usuario>> Editar([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioEditado = await _usuarioServices.Editar(usuario);
                return Ok(usuarioEditado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioServices.GetbyId(id);
                if (usuario == null)
                    return NotFound($"Usuario con id {id} no encontrado");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public ActionResult EliminarUsuario(int id)
        {
            try
            {
                var eliminado = _usuarioServices.EliminarUsuario(id);
                if (!eliminado)
                    return NotFound($"Usuario con id {id} no encontrado");

                return Ok($"Usuario con id {id} eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}