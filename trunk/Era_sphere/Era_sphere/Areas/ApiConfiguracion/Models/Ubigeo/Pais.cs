using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Era_sphere.Generics;

namespace Era_sphere.Areas.ApiConfiguracion.Models
{
    public class Pais: DBable
    {
        public virtual ICollection<Ciudad> ciudades { get; set; }
    }

    
}