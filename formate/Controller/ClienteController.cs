using System.Collections.Generic;
using System.Threading.Tasks;
using formate.Models.Entities;
using formate.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace formate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteService;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteService = clienteServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            try
            {
                var clientes = await _clienteService.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Cliente>> Crear([FromBody] Cliente cliente)
        {
            try
            {
                var nuevoCliente = await _clienteService.Crear(cliente);
                return Ok(nuevoCliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<Cliente>> Editar([FromBody] Cliente cliente)
        {
            try
            {
                var nuevoCliente = await _clienteService.Editar(cliente);
                return Ok(nuevoCliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetbyId(id);
                if (cliente == null)
                    return NotFound($"Usuario con id {id} no encontrado");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public ActionResult EliminarCliente(int id)
        {
            try
            {
                var eliminado = _clienteService.EliminarCliente(id);
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
