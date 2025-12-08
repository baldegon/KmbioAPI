using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KmbioAPI.Services;
using KmbioAPI.DTOs;
using KmbioAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;

namespace KmbioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GastoController : ControllerBase
    {

        private readonly GastoService _gastoService;
        //private readonly KmbioDbContext _context;

        public GastoController(GastoService gastoService)
        {
            _gastoService = gastoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RegistrarGasto([FromBody] GastoRegistroDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado");
            }

            try
            {
                var nuevoGastoModel = await _gastoService.RegistrarGastoAsync(dto, userId);

                return CreatedAtAction(nameof(GetGasto), new { id = nuevoGastoModel.Id }, nuevoGastoModel);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { mensaje = "occurio un error interno al procesar el gasto" });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGasto(int id)
        {
            return Ok();
        }


    }
}
