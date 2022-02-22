using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbHorario
    {
        public TbHorario()
        {
            TbEstudiantes = new HashSet<TbEstudiante>();
        }

        public int Id { get; set; }
        public string Horario { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<TbEstudiante> TbEstudiantes { get; set; }
    }
}
