using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Recomendacione
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? PresupuestoId { get; set; }

    public decimal Balance { get; set; }

    public string? TipoDeInversion { get; set; }

    public DateTime CreatedAt { get; set; }

    public int UsuarioId { get; set; }

    public virtual Capitale? Presupuesto { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
