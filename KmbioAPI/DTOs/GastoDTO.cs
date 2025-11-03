using KmbioAPI.Models;

namespace KmbioAPI.DTOs
{
    public class GastoDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MetodoPagoId { get; set; }

        public decimal Monto { get; set; }

        public string Currency { get; set; } = null!;

        public string? Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public int? CategoriaId { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public int MetodoDePagoId { get; set; }

        public string  NombreCategoria { get; set; }

        public string NombreMetodoDePago { get; set; } = null!;

        public string NombreUser { get; set; } = null!;
    }
}
