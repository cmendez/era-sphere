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
        public ICollection<Ambiente> lista_ambientes { get; set; }
        public ICollection<Habitacion> lista_habitaciones { get; set; }
        public string descripcion { get; set; }

        public int numero_piso { get; set; }

    }
}