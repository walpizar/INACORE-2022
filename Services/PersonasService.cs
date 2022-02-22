using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PersonasService : IPersonaService 
    {
        public IPersonaData PersonaData { get; }
        public PersonasService(IPersonaData _personaData)
        {
            PersonaData = _personaData;
        }


        public TbPersona getByIdent(string ident)
        {
            return PersonaData.getByIdent(ident);
        }
    }
}
