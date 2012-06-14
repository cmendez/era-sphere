using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class Campo: DBable
    {
        public string name { get; set; }
        [ForeignKey("tiposervicio")]
        public int tiposervicioID { get; set; }
        public virtual TipoServicio tiposervicio { get; set; }
    }
}