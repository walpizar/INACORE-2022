using Common.Exceptions;
using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class EstudiantesService : IServices<TbEstudiante>
    {

        public IData<TbEstudiante> EstudianteData { get; }
        public IPersonaData PersonaData { get; }

        public EstudiantesService(IData<TbEstudiante> _estudianteData, IPersonaData personaData)
        {
            EstudianteData = _estudianteData;
            PersonaData = personaData;
        }


        public bool delete(TbEstudiante entity)
        {
            return EstudianteData.delete(entity);
        }

        public IEnumerable<TbEstudiante> getAll()
        {
            return EstudianteData.getAll();
        }

        public TbEstudiante getById(int id)
        {
            return EstudianteData.getById(id);
        }

        public TbEstudiante save(TbEstudiante entity)
        {
            //regla de negocio
            //validar si existe el estudiante
            //ver si exste la persona atravez de identificador, 

            TbPersona persona = PersonaData.getByIdent(entity.IdPersonaNavigation.Identificacion);

            int id= 0;

            if (persona != null)
            {
                //valida si existe como estudiente
                if (persona.TbEstudiantes.Count > 0)
                {
                    throw new EntityExistException("Estudiante");
                }

                persona.Nombre = entity.IdPersonaNavigation.Nombre;
                persona.Apellido1 = entity.IdPersonaNavigation.Apellido1;
                persona.Apellido2 = entity.IdPersonaNavigation.Apellido2;

                entity.IdPersonaNavigation = persona;
                entity.IdPersona = persona.Id;
            }
            else
            {
                id = PersonaData.getNextId();

                entity.IdPersona = id;
                entity.IdPersonaNavigation.Id = id;
            }           


            return EstudianteData.save(entity);          

        }

        public TbEstudiante update(TbEstudiante entity)
        {

            //TAREA
            return EstudianteData.update(entity);
        }
    }
}
