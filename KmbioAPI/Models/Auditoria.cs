using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Auditoria
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Accion { get; set; } = null!;

    public string? TargetType { get; set; }

    public int? TargetId { get; set; }

    public string? Detalle { get; set; }

    public DateTime Fecha { get; set; }

    public string? Meta { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
