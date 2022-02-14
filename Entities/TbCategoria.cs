using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbCategoria
    {
        public TbCategoria()
        {
            TbProductos = new HashSet<TbProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbProducto> TbProductos { get; set; }
    }
}
