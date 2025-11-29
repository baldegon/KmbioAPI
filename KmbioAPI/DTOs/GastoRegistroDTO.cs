using System.ComponentModel.DataAnnotations;

namespace KmbioAPI.DTOs
{
    public class GastoRegistroDTO
    {
        [Required(ErrorMessage="El monto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage="El monto debe ser mayor a cero")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage="La moneda es requerida")]
        public string Currency { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage ="La fecha es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="La categoria es requerida")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="El metodo de pago es requerido")]
        public int MetodoDePagoId { get; set; }
    }
}
