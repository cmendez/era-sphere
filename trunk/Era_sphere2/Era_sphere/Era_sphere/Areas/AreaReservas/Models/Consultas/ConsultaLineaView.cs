using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaReservas.Models{
   
    public class ConsultaLineaView
    {

        public int habitacionID { get; set; }

        [DisplayName(@"Habitación")]
        public string numero_habitacion { get; set; }

        [DisplayName(@"Tipo Habitación")]
        public int tipo_habitacionID { get; set; }
    }
}