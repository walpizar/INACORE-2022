using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CategoriasService: IServices<TbCategoria>
    {

        private IData<TbCategoria> CategoriaData { get; }


        public CategoriasService(IData<TbCategoria> _categoriaData)
        {
            CategoriaData = _categoriaData;
        }


        public bool delete(TbCategoria entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCategoria> getAll()
        {
            return CategoriaData.getAll();
        }

        public TbCategoria getById(int id)
        {
            throw new NotImplementedException();
        }

        public TbCategoria save(TbCategoria entity)
        {
            //aplicar regla de negocio

            return CategoriaData.save(entity);

        }

        public TbCategoria update(TbCategoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
