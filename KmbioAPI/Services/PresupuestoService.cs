using KmbioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KmbioAPI.Services
{
    public class PresupuestoService
    {
        private readonly KmbioDbContext _context;

        public PresupuestoService(KmbioDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> ObtenerGastoTotalEnPeriodo(string userId, DateTime inicio, DateTime fin)
        {
            var totalGastado = await _context.Gastos
                .Where(g => g.UserId == userId && g.Fecha >= inicio && g.Fecha <= fin)
                .SumAsync(g => g.Monto);

            return totalGastado;
        }

    }
}
