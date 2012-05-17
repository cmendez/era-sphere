using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Pais: DBable
    {
       [Required(ErrorMessage = "Requerido")]
       [DisplayName("Nombre del pais")]
       public string nombre { get; set; }
       //public virtual ICollection<Ciudad> ciudades { get; set; }
       public List<Ciudad> ciudades { get; set; }
       public Pais(string p)
       {
           this.nombre = p;
       }
       public Pais()
       {

       }
    }

    public class PaisDBContext:DbContext {
        public DbSet<Pais> Paises { get; set; }
    }
}