using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class ClientesData : IData<clsClientes>
    {
        //lista para guardar a niuvel de memoria
        private List<clsClientes> listaCliente;



        public ClientesData()
        {
            listaCliente = new List<clsClientes>();
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

            return listaCliente.Where(x => x.id == id).SingleOrDefault();

        }

        public clsClientes save(clsClientes entity)
        {
            listaCliente.Add(entity);
            return entity;
        }

        public clsClientes update(clsClientes entity)
        {
            throw new NotImplementedException();
        }
    }
}
