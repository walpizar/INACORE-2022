using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class GruposData : IData<TbGrupo>
    {
        public dbPOOContext Context { get; }
        public GruposData(dbPOOContext _context)
        {
            Context = _context;
        }

       

        public bool delete(TbGrupo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbGrupo> getAll()
        {
            try
            {

                return Context.TbGrupos.Where(x => x.Estado == true).ToList();
                
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public TbGrupo getById(int id)
        {
            try
            {

                return Context.TbGrupos.Where(x => x.Id == id).SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }
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
