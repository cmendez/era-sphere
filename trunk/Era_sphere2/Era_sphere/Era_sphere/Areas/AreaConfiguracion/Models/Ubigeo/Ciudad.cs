using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Ciudad : DBable
    {
        [Required(ErrorMessage="Requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Requerido")]
        public Pais pais { get; set; }
        public List<Provincia> Provincias { get; set; }
    }

    public class CiudadDBContext : DbContext
    {
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}