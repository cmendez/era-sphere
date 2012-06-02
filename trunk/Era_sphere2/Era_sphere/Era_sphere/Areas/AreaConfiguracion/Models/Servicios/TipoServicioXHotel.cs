using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class TipoServicioXHotel: DBable
    {
        public decimal costo_base { get; set; }
        [ForeignKey("tipo_servicio")]
        public int tipo_servicioID { get; set; }
        [ForeignKey("hotel")]
        public int hotelID { get; set; }

        public TipoServicio tipo_servicio { get; set; }
        public Hotel hotel { get; set; }
        
    }
}