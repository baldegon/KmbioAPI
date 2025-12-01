using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Gasto
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public decimal Monto { get; set; }

    public string Currency { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public int? CategoriaId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int MetodoDePagoId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual MetodosDePago MetodoDePago { get; set; } = null!;

    public virtual Usuario User { get; set; } = null!;
}
