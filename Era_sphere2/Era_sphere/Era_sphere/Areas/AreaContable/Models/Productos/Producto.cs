using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Productos
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }

        public String descripcion { get; set; }
    }
}