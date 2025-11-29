using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KmbioAPI.Services;
using KmbioAPI.DTOs;
using KmbioAPI.Context;
using KmbioAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<IActionResult> RegistrarGasto([FromBody] GastoRegistroDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado");
            }

            var nuevoGastoModel = await _gastoService.RegistrarGastoAsync(dto, userId);

            return CreatedAtAction(nameof(GetGasto), new { id = nuevoGastoModel.Id }, nuevoGastoModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGasto(int id)
        {
            return Ok();
        }


        [HttpGet]
        [Route("Gastos")]
        public async Task<ActionResult<List<GastoDTO>>> GetAllGastos()
        {
            var gastos = await _context.Gastos
                .Select(g => new GastoDTO
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    MetodoPagoId = g.MetodoPagoId,
                    Monto = g.Monto,
                    Currency = g.Currency,
                    Descripcion = g.Descripcion,
                    Fecha = g.Fecha,
                    CategoriaId = g.CategoriaId,
                    Status = g.Status,
                    CreatedAt = g.CreatedAt
                })
                .ToListAsync();
            return Ok();
        }
    }
}
