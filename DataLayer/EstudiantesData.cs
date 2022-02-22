using Common.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class EstudiantesData : IData<TbEstudiante>
    {
        public dbPOOContext Context { get; }

        public EstudiantesData(dbPOOContext _context)
        {
            Context = _context;
        }



        public bool delete(TbEstudiante entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbEstudiante> getAll()
        {
            try
            {
                //falta algo
                return Context.TbEstudiantes.Include("IdPersonaNavigation").Include("IdGrupoNavigation").Include("IdHorarioNavigation").Where(x => x.Estado == true).ToList();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TbEstudiante getById(int id)
        {
            throw new NotImplementedException();
        }

        public TbEstudiante save(TbEstudiante entity)
        {
            try
            {
                //Context.Entry<TbPersona>(entity.IdPersonaNavigation).State = EntityState.Modified;
                Context.TbEstudiantes.Add(entity);
                Context.SaveChanges();
                return entity;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TbEstudiante update(TbEstudiante entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
