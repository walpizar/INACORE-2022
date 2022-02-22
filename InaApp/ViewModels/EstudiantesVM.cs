using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaApp.ViewModels
{
    public class EstudiantesVM
    {
        public int Id { get; set; }
        public string Carnet { get; set; }
        public int IdGrupo { get; set; }
        public int IdPersona { get; set; }
        public int IdHorario { get; set; }

        public PersonasVM IdPersonaNavigation { get; set; }
        public GrupoVM IdGrupoNavigation { get; set; }
        public HorariosVM IdHorarioNavigation { get; set; }


    }
}
