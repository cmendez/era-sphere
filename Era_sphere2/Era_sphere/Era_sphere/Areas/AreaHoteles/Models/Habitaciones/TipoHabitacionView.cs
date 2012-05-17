using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacionView

    {
        public TipoHabitacionView() { }
        public TipoHabitacionView(TipoHabitacion tipoHabitacion)
        {
            descripcion = tipoHabitacion.descripcion;
        }
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("Capacidad maxima")]
        public int cap_max_personas { get; set; }

        public TipoHabitacion deserializa(InterfazLogicaTipoHabitacion logica)
        {
            return new TipoHabitacion
            {
                descripcion=this.descripcion,
                cap_max_personas=this.cap_max_personas

            };
        }
    }
}