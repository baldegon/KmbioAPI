using KmbioAPI.Models;
using KmbioAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace KmbioAPI.Services
{
    public class GastoService
    {
        private readonly KmbioDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public GastoService(KmbioDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Gasto> RegistrarGastoAsync(GastoRegistroDTO dto, string identityUserId)
        {
            var user = await _userManager.FindByIdAsync(identityUserId);

            if(user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            if(!int.TryParse(identityUserId, out int userIdInterno))
            {
                throw new Exception("ID de usuario inválido");
            }

            var nuevoGasto = new Gasto
            {
                UserId = userIdInterno,
                Monto = dto.Monto,
                Currency = dto.Currency,
                Descripcion = dto.Descripcion,
                Fecha = dto.Fecha,
                CategoriaId = dto.CategoriaId,
                MetodoDePagoId = dto.MetodoDePagoId,
                Status = "COMPLETADO",
                CreatedAt = DateTime.UtcNow
            };

            _context.Gastos.Add(nuevoGasto);
            await _context.SaveChangesAsync();

            return nuevoGasto;

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
