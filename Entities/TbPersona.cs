using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbPersona
    {
        public TbPersona()
        {
            TbEstudiantes = new HashSet<TbEstudiante>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string TipoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<TbEstudiante> TbEstudiantes { get; set; }
    }
}
