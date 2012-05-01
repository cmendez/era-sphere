using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.ApiConfiguracion.Models
{
    public class Ciudad
    {
        public int ciudadID { get; set; }
        public Provincia provincia { get; set; }
    }
}