using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HabitacionView
    {
        public HabitacionView() { }
        public HabitacionView(Habitacion habitacion)
        {
            detalle = habitacion.detalle;
            estado = habitacion.estado;
            ID = habitacion.ID;
            tipoHabitacion = habitacion.tipoHabitacion;
        }
        [DisplayName("Detalle")]
        public string detalle { get; set; }
        [DisplayName("estado")]
        public string estado { get; set; }
        [DisplayName("ID Habitacion")]
        public int ID { get; set; }
        [DisplayName("Tipo de habitacion")]
        string tipoHabitacion { get; set; }
        public Habitacion deserializa(InterfazLogicaHabitacion logica)
        {
            return new Habitacion
            {
                detalle = this.detalle,
                estado = this.estado,
                ID = this.ID,
                tipoHabitacion = this.tipoHabitacion
            };
        }
        
    }
}