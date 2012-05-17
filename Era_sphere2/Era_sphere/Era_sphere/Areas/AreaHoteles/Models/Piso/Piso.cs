using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Piso:DBable
    {
        public string descripcion { get; set; }

        public Hotel hotel { get; set; }

        public List<EspacioCargable> espacio_cargable { get; set; }

    }
}