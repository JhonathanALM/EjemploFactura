using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFacturas.Models
{
    public class Detalle
    {
        public int DetalleId { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
