using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class ConsultaView
    {

        [DisplayName("Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [DisplayName("Fecha Fin")]
        public DateTime fecha_fin { get; set; }

        [DisplayName(@"Número de Piso")]
        public int pisoID { get; set; }

        
       


        public int hotelID { get; set; }

        [DisplayName("Habitaciones Libres")]
        public int habitaciones_libres_total { get; set; }
        
        [DisplayName("Libres por Piso")]
        public int habitaciones_libres_piso { get; set; }

        [DisplayName("Libres por Tipo")]
        public int habitaciones_libres_tipo { get; set; }
    }

}