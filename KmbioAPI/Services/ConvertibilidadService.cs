using KmbioAPI.Models;

namespace KmbioAPI.Services
{
    public class ConvertibilidadService
    {
        private readonly KmbioDbContext _context;
        public ConvertibilidadService(KmbioDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<ConvertibilidadDTO> GetAllConvertibilidades()
        {
            return _context.Convertibilidades.Select(c => new ConvertibilidadDTO
            {
                Id = c.Id,
                MonedaOrigen = c.MonedaOrigen,
                MonedaDestino = c.MonedaDestino,
                Tasa = c.Tasa,
                FechaActualizacion = c.FechaActualizacion
            }).ToList();
        }
    }
}
