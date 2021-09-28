using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFacturas.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Telefono { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }
    }
}
