using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.Configuracion.Models;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Provincia: DBable
    {
        public string nombre { get; set; }
        public Ciudad ciudad { get; set; }
        public Pais pais { get; set; }
    }

    public class ProvinciaDBContext : DbContext
    {
        public DbSet<Provincia> Provincias { get; set; }
    }
}