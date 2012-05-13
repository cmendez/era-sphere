using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Pais: DBable
    {
       public string nombre { get; set; }
       //public virtual ICollection<Ciudad> ciudades { get; set; }
    }

    
}