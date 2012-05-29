using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaHoteles.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaPaquetes.Models.PaqueteXTipoHabitacion
{
    public class PaqueteXTipoHabitacion
    {
        [Required]
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }
        
        [Required]
        [ForeignKey("paquete")]
        public int paqueteID { get; set; }

        [Required]
        [Range(1,5)]
        public int cantidad { get; set; }

        [Required]
        [Range(1, 5)]
        public int noches { get; set; }

        public virtual TipoHabitacion tipoHabitacion { get; set; }
        public virtual Paquete paquete { get; set; }
    }
}