using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbProveedore
    {
        public TbProveedore()
        {
            TbProductos = new HashSet<TbProducto>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<TbProducto> TbProductos { get; set; }
    }
}
