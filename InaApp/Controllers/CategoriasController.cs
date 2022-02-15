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
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {

        private IServices<TbCategoria> CategoriaService { get; }
        public IMapper Mapper { get; }

        public CategoriasController(IServices<TbCategoria> _CategoriaService, IMapper _mapper)
        {

            CategoriaService = _CategoriaService;
            Mapper = _mapper;
        }

     
        //GET BY ID

        //UPDATE PATCH

        //DELETE DELETE

        [HttpGet]
        public ActionResult getAll()
        {
            try
            {

               IEnumerable< TbCategoria> lista = CategoriaService.getAll();



              //  var listaVM = Mapper.Map<List<CategoriasVM>>(lista);

               
                var listaVM = Mapper.Map<IEnumerable<TbCategoria>, IEnumerable<CategoriasVM>>(lista);



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


        [HttpPost]
        public ActionResult post([FromBody] CategoriasVM categoriaVM)
        {
            try
            {

                if (!validar(categoriaVM))
                {
                    return BadRequest("Faltan datos");
                }

                //convierto a entidad el view model, realizo mapeo
                TbCategoria categoria = Mapper.Map<TbCategoria>(categoriaVM);

                //por aquello de las moscas lo paso a 0 para no generar excepcion xq es auto incremental.
                categoria.Id = 0;

                //envio a guardar
                categoria = CategoriaService.save(categoria);

                //siempre devulevo un view model
                categoriaVM = Mapper.Map<CategoriasVM>(categoria);

                //retorno vm con el id asignado por la base datos y un 201, ok.
                return Ok(categoriaVM);
            }
            catch (Exception)
            {

                return StatusCode(400);
            }

        }

        private bool validar(CategoriasVM categoriaVM)
        {

            //if (categoriaVM.Id == 0)
            //{
            //    return false;
            //}
            if(categoriaVM.Nombre==null || categoriaVM.Nombre == string.Empty)
            {
                return false;
            }

            return true;
        }
    }

}
