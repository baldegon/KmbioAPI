using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace KmbioAPI.Models;

public partial class Convertibilidade
{
    public int Id { get; set; }

    public string MonedaOrigen { get; set; } = null!;

    public string MonedaDestino { get; set; } = null!;

    public decimal Tasa { get; set; }

    public DateTime FechaActualizacion { get; set; }
}

public class ConvertibilidadDTO
{
    public int Id { get; set; }
    public string MonedaOrigen { get; set; } = null!;
    public string MonedaDestino { get; set; } = null!;
    public decimal Tasa { get; set; }
    public DateTime FechaActualizacion { get; set; }
}
