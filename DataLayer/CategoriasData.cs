using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class CategoriasData : IData<TbCategoria>
    {
        private dbPOOContext Context { get; }
        public CategoriasData( dbPOOContext _context)
        {
            Context = _context;
        }

 

        public bool delete(TbCategoria entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCategoria> getAll()
        {
            try
            {
              return Context.TbCategorias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
  
        }

        public TbCategoria getById(int id)
        {
            throw new NotImplementedException();
        }

        public TbCategoria save(TbCategoria entity)
        {
            try
            {
                Context.TbCategorias.Add(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public TbCategoria update(TbCategoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
