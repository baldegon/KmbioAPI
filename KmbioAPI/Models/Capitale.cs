using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Capitale
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal CapitalTotal { get; set; }

    public string? Currency { get; set; }

    public DateTime LastUpdate { get; set; }

    public string? Note { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Recomendacione> Recomendaciones { get; set; } = new List<Recomendacione>();

    public virtual Usuario Usuario { get; set; } = null!;
}
