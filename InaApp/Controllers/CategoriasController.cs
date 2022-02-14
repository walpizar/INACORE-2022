using Common.Interfaces;
using Entities;
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
        public CategoriasController(IServices<TbCategoria> _CategoriaService)
        {

            CategoriaService = _CategoriaService;
        }



        [HttpGet]
        public ActionResult getAll()
        {
            try
            {

                var lista = CategoriaService.getAll();
                return Ok(lista);

            }
            catch (Exception ex)
            {

                return StatusCode(400);
            }

        }


    }

}
