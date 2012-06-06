using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class Consulta
    {
        //verificar que puede ir como modelo   [DisplayName("Fecha Inicio")]
        
        public DateTime fecha_inicio { get; set; }
                
        public DateTime fecha_fin { get; set; }

        public int pisoID { get; set; }

        public int habitacionID { get; set; }

        public int tipo_habitacionID { get; set; }
        
        public int hotelID { get; set; }

        public int habitaciones_libres_total { get; set; }
        
        public int habitaciones_libres_piso { get; set; }

        public int habitaciones_libres_tipo { get; set; }

        public List<Habitacion> habitaciones_resultantes { get; set; }

    }
}