using System;
using System.Collections.Generic;

namespace Educacion_backend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public decimal Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
