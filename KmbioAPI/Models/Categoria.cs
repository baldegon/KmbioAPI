using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<GastosRecurrente> GastosRecurrentes { get; set; } = new List<GastosRecurrente>();

    public virtual Usuario? Usuario { get; set; } = null!;
}
