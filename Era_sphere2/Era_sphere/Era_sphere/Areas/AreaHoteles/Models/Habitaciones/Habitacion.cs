    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Habitacion: EspacioRentable
    {
        
        public string detalle { get; set; }

        public ICollection<Comodidad> comodidades { get; set; }
        [Required]
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }

        public virtual TipoHabitacion tipoHabitacion { get; set; }
        [Required]
        [ForeignKey("estado_habitacion")]
        public int estado_habitacionID { get; set; }
        public virtual EstadoHabitacion estado_habitacion { get; set; }
 
    }
}