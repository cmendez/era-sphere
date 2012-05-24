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
        public ICollection<Comodidad> comodidades { get; set; }
        [Required]
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }

        public virtual TipoHabitacion tipoHabitacion { get; set; }
 
    }
}