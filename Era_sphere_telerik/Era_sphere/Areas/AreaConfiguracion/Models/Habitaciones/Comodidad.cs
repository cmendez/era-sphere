using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Habitaciones
{
    public class Comodidad : DBable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        //public int estadoID { get; set; }
    }
}