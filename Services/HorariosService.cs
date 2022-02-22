using Common.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class HorariosService : IServices<TbHorario>
    {

        public IData<TbHorario> HorariosData { get; }

        public HorariosService(IData<TbHorario> _horariosData)
        {
            HorariosData = _horariosData;
        }


        public bool delete(TbHorario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbHorario> getAll()
        {
            return HorariosData.getAll();
        }

        public TbHorario getById(int id)
        {
            return HorariosData.getById(id);
        }

        public TbHorario save(TbHorario entity)
        {
            throw new NotImplementedException();
        }

        public TbHorario update(TbHorario entity)
        {
            throw new NotImplementedException();
        }
    }
}
