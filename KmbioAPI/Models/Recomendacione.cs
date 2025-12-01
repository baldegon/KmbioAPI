using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Recomendacione
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int? PresupuestoId { get; set; }

    public decimal Balance { get; set; }

    public string? TipoDeInversion { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Capitale? Presupuesto { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
