using KmbioAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace KmbioAPI.DTOs
{
    public class GastoDTO
    {
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public string Currency { get; set; } = null!;
        public string? Descripcion { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int? CategoriaId { get; set; }
        [Required]
        public int MetodoDePagoId { get; set; }
        public string NombreCategoria { get; set; } = null!;
        
        public string NombreMetodoDePago { get; set; } = null!;
        public string NombreUser { get; set; } = null!;

    }
}
