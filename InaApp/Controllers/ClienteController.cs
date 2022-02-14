
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
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private IServices<clsClientes> ClienteService { get; }
        public IMapper Imapper { get; }

        //inyecciojn de dependencias para cliente servicios
        public ClienteController(IServices<clsClientes> _clienteService, IMapper _imapper)
        {
            //asignacion de la inyeccion a la variable global
            ClienteService = _clienteService;
            Imapper = _imapper;
        }


        [HttpGet]
        public ActionResult getAll()
        {
            //return BadRequest();//400
            //return Ok();//200
            return Ok("estoy en getAll()");//especificar un codigo 
                                           // return new Object();
        }

        [HttpGet("byId/{id}")]
        public ActionResult getById(int id)
        {
            try
            {

                clsClientes cliente = ClienteService.getById(id);
                ClientesVM clienteVm = Imapper.Map<ClientesVM>(cliente);


                return Ok(clienteVm);//especificar un codigo 
                                     // return new Object();

            }
            catch (EntityNoExistException ex)
            {

                return StatusCode(400);
            }
            catch (Exception)
            {

                return StatusCode(400);
            }   

        }

        [HttpPost]
        public ActionResult post([FromBody] ClientesVM clienteVm)
        {
            try
            {

                //valide datos de entrada
                //
                clsClientes newCliente = Imapper.Map<clsClientes>(clienteVm);


                //newCliente.id = clienteVm.id;
                //newCliente.nombre = clienteVm.nombre;
                //newCliente.apellido1 = clienteVm.apellido1;
                //newCliente.apellido2 = clienteVm.apellido2;

                //vamos a la capa de servicios
                newCliente = ClienteService.save(newCliente);


                //return BadRequest();//400
                //return Ok();//200
                return StatusCode(201);//especificar un codigo 
                                       // return new Object();

            }
            catch (Exception)
            {

                return StatusCode(400);
            }

        }


        public bool validar(ClientesVM cliente)
        {





            return true;


        }
        [HttpPatch("{id}")]
        public ActionResult update(int id, [FromBody] ClientesVM clienteVm)
        {
            try
            {

              
               

                //return BadRequest();//400
                //return Ok();//200
                return StatusCode(201);//especificar un codigo 
                                       // return new Object();

            }
            catch (Exception)
            {

                return StatusCode(400);
            }

        }

        [HttpPatch("{id}")]
        public ActionResult delete(int id)
        {
            try
            {

               


                //return BadRequest();//400
                //return Ok();//200
                return StatusCode(201);//especificar un codigo 
                                       // return new Object();

            }
            catch (Exception)
            {

                return StatusCode(400);
            }

        }




    }
}
