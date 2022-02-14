using Common.Exceptions;
using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ClientesService : IServices<clsClientes>
    {


        public IData<clsClientes> ClienteData { get; }

        public ClientesService(IData<clsClientes> _ClienteData)
        {
            ClienteData = _ClienteData;
        }


        public bool delete(clsClientes entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<clsClientes> getAll()
        {
            throw new NotImplementedException();
        }

        public clsClientes getById(int id)
        {
            try
            {
                var cliente= ClienteData.getById(id);
                if (cliente == null)
                {
                    throw new EntityNoExistException("Cliente");
                }

                return cliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public clsClientes save(clsClientes entity)
        {
            //reglas de negocio
            return ClienteData.save(entity);
        }

        public clsClientes update(clsClientes entity)
        {
            throw new NotImplementedException();
        }
    }
}
