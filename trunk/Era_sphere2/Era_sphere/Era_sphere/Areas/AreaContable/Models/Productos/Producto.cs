using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class Producto : DBable
    {
        public String descripcion { get; set; }
    }
}