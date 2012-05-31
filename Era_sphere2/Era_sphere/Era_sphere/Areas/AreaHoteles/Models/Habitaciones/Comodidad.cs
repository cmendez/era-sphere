using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class Comodidad : DBable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [ForeignKey("tipoHabitacion")]
        public int tipoHabitacionID { get; set; }
        [Required]
        public virtual TipoHabitacion tipoHabitacion { get; set; }
    }
}