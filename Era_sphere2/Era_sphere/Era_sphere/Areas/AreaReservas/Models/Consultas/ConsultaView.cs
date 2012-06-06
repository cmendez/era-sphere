using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaReservas.Models.Consultas
{
    public class ConsultaView
    {

        [DisplayName("Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [DisplayName("Fecha Fin")]
        public DateTime fecha_fin { get; set; }


        public int habitaciones_libres_total { get; set; }


        public int habitaciones_libres_piso { get; set; }
    
    }

}