using KmbioAPI.Models;
using KmbioAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KmbioAPI.Services
{
    public class GastoService
    {
        private readonly KmbioDbContext _context;

        public GastoService(KmbioDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult<GastoDTO>> GetAllGastos()
        {
            return _context.Gastos.Select(g => new GastoDTO
            {
                Id = g.Id,
                Descripcion = g.Descripcion,
                Monto = g.Monto,
                Fecha = g.Fecha,
                CategoriaId = g.CategoriaId
            }).ToList();
        }
    }
}
