using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class GastosRecurrente
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public decimal Monto { get; set; }

    public string Currency { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string FrecuenciaKind { get; set; } = null!;

    public string? Schedule { get; set; }

    public DateTime? NextRun { get; set; }

    public bool Active { get; set; }

    public int? CategoriaId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? MetodoDePagoId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual MetodosDePago? MetodoDePago { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
