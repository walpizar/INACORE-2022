using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class HorariosData : IData<TbHorario>
    {
        public dbPOOContext Context { get; }

        public HorariosData(dbPOOContext _context)
        {
            Context = _context;
        }

    

        public bool delete(TbHorario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbHorario> getAll()
        {
            try
            {
                return Context.TbHorarios.Where(x => x.Estado == true).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TbHorario getById(int id)
        {
            try
            {
                return Context.TbHorarios.Where(x => x.Id == id).SingleOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TbHorario save(TbHorario entity)
        {
            throw new NotImplementedException();
        }

        public TbHorario update(TbHorario entity)
        {
            throw new NotImplementedException();
        }
    }
}
