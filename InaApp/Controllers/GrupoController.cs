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
    [Route("api/grupo")]
    public class GrupoController: ControllerBase
    {
        public IServices<TbGrupo> GrupoService { get; }
        public IMapper Mapper { get; }

        public GrupoController(IServices<TbGrupo> _grupoService, IMapper _mapper)
        {
            GrupoService = _grupoService;
            Mapper = _mapper;
        }



        [HttpGet]
        public ActionResult getAll()
        {
            try
            {

                IEnumerable<TbGrupo> lista = GrupoService.getAll();



                //  var listaVM = Mapper.Map<List<CategoriasVM>>(lista);


                var listaVM = Mapper.Map<IEnumerable<TbGrupo>, IEnumerable<GrupoVM>>(lista);

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
