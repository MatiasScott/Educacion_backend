using System;
using System.Collections.Generic;

namespace Educacion_backend.Models
{
    public partial class Materium
    {
        public Materium()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public decimal Id { get; set; }
        public decimal? IdColegio { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int? NumeroEstudiantes { get; set; }
        public string? DocenteAsignado { get; set; }
        public string? Curso { get; set; }
        public string? Paralelo { get; set; }

        public virtual Colegio? IdColegioNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
