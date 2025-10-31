using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class MetodosDePago
{
    public int Id { get; set; }

    public string NombreMetodo { get; set; } = null!;

    public int? UserId { get; set; }

    public string? Details { get; set; }

    public bool Active { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<GastosRecurrente> GastosRecurrentes { get; set; } = new List<GastosRecurrente>();

    public virtual Usuario? Usuario { get; set; }
}
