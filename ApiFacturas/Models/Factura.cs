using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFacturas.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public List<Detalle> Detalles { get; set; }
    }
}
