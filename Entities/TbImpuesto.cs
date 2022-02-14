using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbImpuesto
    {
        public TbImpuesto()
        {
            TbProductos = new HashSet<TbProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Valor { get; set; }

        public virtual ICollection<TbProducto> TbProductos { get; set; }
    }
}
