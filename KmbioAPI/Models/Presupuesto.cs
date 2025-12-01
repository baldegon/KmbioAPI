using System;
using System.Collections.Generic;

namespace KmbioAPI.Models
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal MontoLimite { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Frecuencia { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Recomendacione> Recomendaciones { get; set; } = new List<Recomendacione>();

    }
}
