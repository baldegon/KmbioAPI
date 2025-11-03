using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KmbioAPI.Services;
using KmbioAPI.DTOs;
using KmbioAPI.Context;
using KmbioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly KmbioDbContext _context;

        public GastoController(KmbioDbContext context)
        {
            _context = context;
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
