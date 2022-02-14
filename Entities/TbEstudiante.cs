using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbEstudiante
    {
        public int Id { get; set; }
        public string Carnet { get; set; }
        public int? Grupo { get; set; }
        public int? IdPersona { get; set; }
        public string Horario { get; set; }
        public bool? Estado { get; set; }

        public virtual TbPersona IdPersonaNavigation { get; set; }
    }
}
