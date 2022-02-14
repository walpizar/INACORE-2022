using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class TbProducto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Utilidad { get; set; }
        public int IdImpuesto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string IdProveedor { get; set; }
        public bool Estado { get; set; }

        public virtual TbCategoria IdCategoriaNavigation { get; set; }
        public virtual TbImpuesto IdImpuestoNavigation { get; set; }
        public virtual TbProveedore IdProveedorNavigation { get; set; }
    }
}
