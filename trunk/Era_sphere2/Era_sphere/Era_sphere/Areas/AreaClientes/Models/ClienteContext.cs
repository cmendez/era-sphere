using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Areas.AreaClientes.Models
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
    }
}