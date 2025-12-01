using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Capitale
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public decimal CapitalTotal { get; set; }

    public string? Currency { get; set; }

    public DateTime LastUpdate { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Recomendacione> Recomendaciones { get; set; } = new List<Recomendacione>();

    public virtual Usuario Usuario { get; set; } = null!;
}
