using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace KmbioAPI.Models;

public partial class Usuario : IdentityUser
{

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CurrencyDefault { get; set; }

    public virtual ICollection<Auditoria> Auditoria { get; set; } = new List<Auditoria>();

    public virtual ICollection<Capitale> Capitales { get; set; } = new List<Capitale>();

    public virtual ICollection<Categoria> Categoria { get; set; } = new List<Categoria>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<GastosRecurrente> GastosRecurrentes { get; set; } = new List<GastosRecurrente>();

    public virtual ICollection<MetodosDePago> MetodosDePagos { get; set; } = new List<MetodosDePago>();

    public virtual ICollection<Recomendacione> Recomendaciones { get; set; } = new List<Recomendacione>();
}
