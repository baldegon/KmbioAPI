using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Merchant
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public DateTime CreatedAt { get; set; }
}
