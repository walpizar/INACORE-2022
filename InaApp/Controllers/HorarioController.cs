using AutoMapper;
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
    [Route("api/horario")]
    public class HorarioController: ControllerBase
    {

        public IServices<TbHorario> HorarioService { get; }
        public IMapper Mapper { get; }

        public HorarioController(IServices<TbHorario> _horarioService, IMapper _mapper)
        {
            HorarioService = _horarioService;
            Mapper = _mapper;
        }



        [HttpGet]
        public ActionResult getAll()
        {
            try
            {

                IEnumerable<TbHorario> lista = HorarioService.getAll();

                var listaVM = Mapper.Map<IEnumerable<TbHorario>, IEnumerable<HorariosVM>>(lista);

                //devolver VIEW MODEL CATEGORIAS
                //MEDIANTE AUTOMAPPER MAPEAR LAS LISTA. LISTA DE VIEWMODELS

                //DEVOLVER LISTA DE VIEW MODELS
                return Ok(listaVM);

            }
            catch (Exception ex)
            {

                return StatusCode(400);
            }

        }






    }
}
