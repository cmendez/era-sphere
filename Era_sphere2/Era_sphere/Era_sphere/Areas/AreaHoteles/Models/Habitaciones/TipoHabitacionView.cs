using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacionView

    {
        public TipoHabitacionView() { }
        public TipoHabitacionView(TipoHabitacion tipoHabitacion)
        {
            descripcion = tipoHabitacion.descripcion;
            cap_max_personas = tipoHabitacion.cap_max_personas;
            ID = tipoHabitacion.ID;
        }
        [Required]
        [DisplayName("Descripcion")]
        [StringLength(30)]
        public string descripcion { get; set; }
        [DisplayName("Capacidad maxima")]
        [Range(1,20)]
        public int cap_max_personas { get; set; }
        [DisplayName("ID tipo habitacion")]
        public int ID { get; set; }

        public TipoHabitacion deserializa(InterfazLogicaTipoHabitacion logica)
        {
            return new TipoHabitacion
            {
                descripcion=this.descripcion,
                cap_max_personas=this.cap_max_personas,
                ID=this.ID
            };
        }
    }
}