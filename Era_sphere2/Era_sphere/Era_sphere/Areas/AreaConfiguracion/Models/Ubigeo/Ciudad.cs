using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.Configuracion.Models
{
    public class Ciudad : DBable
    {
        public string nombre { get; set; }
        //public int paisID { get; set; }
        public Pais pais { get; set; }
    }
}