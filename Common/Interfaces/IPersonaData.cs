using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IPersonaData
    {
        //consulto por identificacion string
        TbPersona getByIdent(string ident);
        int getNextId();
    }
}
