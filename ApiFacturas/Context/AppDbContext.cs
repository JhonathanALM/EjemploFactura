using ApiFacturas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFacturas.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Factura> Factura { get; set; }

        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
