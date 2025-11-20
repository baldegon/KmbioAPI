using KmbioAPI.Models;
using KmbioAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KmbioAPI.Services
{
    public class GastoService
    {
        private readonly KmbioDbContext _context;

        public GastoService(KmbioDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<GastoDTO>>> GetAllGastos()
        {
            var result = await _context.Gastos.Select(g => new GastoDTO
            {
                Id = g.Id,
                Descripcion = g.Descripcion,
                Monto = g.Monto,
                Fecha = g.Fecha,
                CategoriaId = g.CategoriaId
            }).ToListAsync();

            return result;
        }
    }
}
