using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class ProductoXServicio:DBable
    {
        [ForeignKey("producto")]
        public int productoID { get; set; }
        [ForeignKey("servicio")]
        public int servicioID { get; set; }
        public int unidades { get; set; }

        public Producto producto { get; set; }
        public Servicio servicio { get; set; }
    }
}