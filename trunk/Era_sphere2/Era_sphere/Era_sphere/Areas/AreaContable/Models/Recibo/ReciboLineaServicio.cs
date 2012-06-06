using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class ReciboLineaServicio: ReciboLinea
    {
        [ForeignKey("servicio")]
        public int servicioID { get; set; }
        public Servicio servicio { get; set; }

    }
}