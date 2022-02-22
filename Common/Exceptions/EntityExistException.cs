using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class EntityExistException: Exception
    {
        public EntityExistException(string entidad):base(string.Format("{0} se encuentra registrado en el base de datos.", entidad))
        {
        }
    }
}
