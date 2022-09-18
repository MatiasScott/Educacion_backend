using System;
using System.Collections.Generic;

namespace Educacion_backend.Models
{
    public partial class Colegio
    {
        public Colegio()
        {
            Calificaciones = new HashSet<Calificacione>();
            Materia = new HashSet<Materium>();
        }

        public decimal Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Materium> Materia { get; set; }
    }
}
