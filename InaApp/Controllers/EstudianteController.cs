using AutoMapper;
using Common.Exceptions;
using Common.Interfaces;
using Entities;
using InaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaApp.Controllers
{
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        public IServices<TbEstudiante> EstudianteService { get; }
        public IServices<TbGrupo> GrupoService { get; }
        public IServices<TbHorario> HorariosService { get; }

        public IMapper Mapper { get; }

        public EstudianteController(IServices<TbEstudiante> _estudianteService, IServices<TbGrupo> _grupoService, IServices<TbHorario> _horariosService,
            IMapper _mapper)
        {
            EstudianteService = _estudianteService;
            GrupoService = _grupoService;
            HorariosService = _horariosService;
            Mapper = _mapper;
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public ActionResult getAll(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Falta ID.");
                }

                var estudiante = EstudianteService.getById(id);

                if (estudiante == null)
                {
                    return BadRequest(string.Format("El estudiante con el ID ({0}) no existe.", id));


                }

                return Ok(estudiante);
            }
            catch (Exception)
            {

                return StatusCode(400);
            }


        }
        [HttpGet]
        public ActionResult getAll()
        {
            try
            {

                IEnumerable<TbEstudiante> lista = EstudianteService.getAll();

                var listaVM = Mapper.Map<IEnumerable<TbEstudiante>, IEnumerable<EstudiantesVM>>(lista);

                return Ok(listaVM);
            }
            catch (Exception ex)
            {

                return StatusCode(400);
            }
        }



        [HttpPost]
        [Route("post")]
        public ActionResult post([FromBody] EstudiantesVM estudianteVM)
        {
            try
            {
                if (!validarDatos(estudianteVM))
                {
                    return BadRequest("Falta datos.");

                }
           


                TbEstudiante estudiante = Mapper.Map<TbEstudiante>(estudianteVM);


                //validar grupo y horarios

                if (GrupoService.getById(estudiante.IdGrupo) == null)
                {
                    return BadRequest("El grupo no existe");
                }

                if (HorariosService.getById(estudiante.IdHorario) == null)
                {
                    return BadRequest("El horario no existe");
                }



                estudiante.Estado = true;

                //mandar a guardar

                estudiante = EstudianteService.save(estudiante);

                return Ok();
            }
            catch (EntityExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(400);
            }

        }

        [HttpPatch("{id}")]
        public ActionResult patch(int id, [FromBody] EstudiantesVM estudianteVM)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("Falta ID.");
                }


                if (!validarDatos(estudianteVM))
                {
                    return BadRequest("Falta datos.");

                }

                

                TbEstudiante estudiante = EstudianteService.getById(id);

                if (estudiante == null)
                {
                    return BadRequest(string.Format("El estudiante con el ID ({0}) no existe.", id));


                }

                estudiante.IdPersonaNavigation.Nombre = estudianteVM.IdPersonaNavigation.Nombre;
                estudiante.IdPersonaNavigation.Apellido1 = estudianteVM.IdPersonaNavigation.Apellido1;
                estudiante.IdPersonaNavigation.Apellido2 = estudianteVM.IdPersonaNavigation.Apellido2;

                estudiante.IdHorario = estudianteVM.IdHorario;
                estudiante.IdGrupo = estudianteVM.IdGrupo;

                //validar grupo y horarios

                if (GrupoService.getById(estudiante.IdGrupo) == null)
                {
                    return BadRequest("El grupo no existe");
                }

                if (HorariosService.getById(estudiante.IdHorario) == null)
                {
                    return BadRequest("El horario no existe");
                }


                estudiante = EstudianteService.update(estudiante);



                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("{Id}")]      
        public ActionResult delete(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return BadRequest("Falta ID.");
                }

                var estudiante = EstudianteService.getById(Id);

                if (estudiante == null)
                {
                    return BadRequest(string.Format("El estudiante con el ID ({0}) no existe.", Id));


                }
                estudiante.Estado = false;
                bool result= EstudianteService.delete(estudiante);

                return Ok();
         
            }
            catch (Exception)
            {

                return StatusCode(400);
            }


        }

        private bool validarDatos(EstudiantesVM estudianteVM)
        {
            if (estudianteVM.Carnet == string.Empty)
            {
                return false;
            }

            if (estudianteVM.IdHorario == 0)
            {
                return false;
            }

            if (estudianteVM.IdGrupo == 0)
            {
                return false;
            }
            //verificao la persona entidad que no este null
            if (estudianteVM.IdPersonaNavigation == null)
            {
                return false;
            }


            if (estudianteVM.IdPersonaNavigation.Identificacion == string.Empty)
            {
                return false;
            }

            if (estudianteVM.IdPersonaNavigation.Nombre == string.Empty)
            {
                return false;
            }


            if (estudianteVM.IdPersonaNavigation.Apellido1 == string.Empty)
            {
                return false;
            }

            if (estudianteVM.IdPersonaNavigation.Apellido2 == string.Empty)
            {
                return false;
            }


            return true;
        }
    }
}
