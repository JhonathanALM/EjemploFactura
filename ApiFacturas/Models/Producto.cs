using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFacturas.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
