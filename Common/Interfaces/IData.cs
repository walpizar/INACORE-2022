using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IData <entity>
    {
        entity save(entity entity);
        IEnumerable<entity> getAll();
        entity getById(int id);
        bool delete(entity entity);
        entity update(entity entity);
    }
}
