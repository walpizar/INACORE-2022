using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class EntityNoExistException : Exception
    {
        public EntityNoExistException(string entidad): base(entidad+ "No existe en la base datos.")
        {
        }
    }
}
