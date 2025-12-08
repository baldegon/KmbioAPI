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
        private readonly PresupuestoService _presupuestoService;

        public GastoService(KmbioDbContext context, UserManager<Usuario> userManager, PresupuestoService presupuestoService)
        {
            _context = context;
            _userManager = userManager;
            _presupuestoService = presupuestoService;
        }

        public async Task<Gasto> RegistrarGastoAsync(GastoRegistroDTO dto, string identityUserId)
        {

            var presupuestoActivo = await _context.Presupuestos
                .FirstOrDefaultAsync(p => p.UserId == identityUserId &&
                                    dto.Fecha >= p.FechaInicio &&
                                    dto.Fecha <= p.FechaFin);

            if(presupuestoActivo != null)
            {
                decimal gastadoActual = await _presupuestoService
                    .ObtenerGastoTotalEnPeriodo(identityUserId, presupuestoActivo.FechaInicio, presupuestoActivo.FechaFin);

                if((gastadoActual + dto.Monto) > presupuestoActivo.MontoLimite)
                {
                    throw new Exception($"Cuidado este gasto puede exceder tu presupuesto de {presupuestoActivo.MontoLimite:C}");
                }
            }

            var nuevoGasto = new Gasto
            {
                UserId = identityUserId,
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

            var capital = await _context.Capitales.FirstOrDefaultAsync(c => c.UserId == identityUserId);

            if (capital != null)
            {
                capital.CapitalTotal -= dto.Monto;
                capital.LastUpdate = DateTime.UtcNow;
                _context.Capitales.Update(capital);
            }

            await _context.SaveChangesAsync();

            return nuevoGasto;

        }

    }
}
