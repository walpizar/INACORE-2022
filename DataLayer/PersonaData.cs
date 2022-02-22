using Common.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class PersonaData : IPersonaData
    {
        public dbPOOContext Context { get; }

        public PersonaData(dbPOOContext _context)
        {
            Context = _context;
        }

       

        public TbPersona getByIdent(string ident)
        {
            try
            {
                return Context.TbPersonas.Include("TbEstudiantes").Where(x => x.Identificacion.Trim() == ident.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int getNextId()
        {
            try
            {

                var lastId = Context.TbPersonas.Max(x => x.Id);

                return  ++lastId;

                //if (lastId == null)
                //{
                //    lastId = 0;
                //}
                //else
                //{
                //    lastId = lastId;
                //}


                //return lastId;

            }
            catch (Exception ex)
            {

                return 1;
            }




        }
    }
}
