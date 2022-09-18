using System;
using System.Collections.Generic;

namespace Educacion_backend.Models
{
    public partial class Calificacione
    {
        public decimal Id { get; set; }
        public decimal? IdColegio { get; set; }
        public decimal? IdMateria { get; set; }
        public decimal? IdUsuario { get; set; }
        public decimal? Calificacion { get; set; }

        public virtual Colegio? IdColegioNavigation { get; set; }
        public virtual Materium? IdMateriaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
