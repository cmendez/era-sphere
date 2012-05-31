using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaPromociones.Models
{
    public class Promocion:DBable
    {
        [DisplayName("Nombre")]
        public string nombre{ get; set; }

        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Puntos requeridos")]
        public int puntos_requeridos { get; set; }

        [DisplayName("Descuento")]
        public int descuento{ get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [DisplayName("Fecha de fin")]
        public DateTime fecha_fin { get; set; }

        //[DisplayName("Ascociado a")]
        //public string asociado_a { get; set; }

        //[DisplayName("Estado")]
        //public string estado { get; set; }
    }
}