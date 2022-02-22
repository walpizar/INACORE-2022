using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Services
{
    public class GruposService : IServices<TbGrupo>
    {
        public IData<TbGrupo> GruposData { get; }

        public GruposService(IData<TbGrupo> _gruposData)
        {
            GruposData = _gruposData;
        }

    

        public bool delete(TbGrupo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbGrupo> getAll()
        {
            return GruposData.getAll();
        }

        public TbGrupo getById(int id)
        {
            return GruposData.getById(id);
        }

        public TbGrupo save(TbGrupo entity)
        {
            throw new NotImplementedException();
        }

        public TbGrupo update(TbGrupo entity)
        {
            throw new NotImplementedException();
        }
    }
}
