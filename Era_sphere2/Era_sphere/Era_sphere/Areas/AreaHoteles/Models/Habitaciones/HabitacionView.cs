using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
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
        string detalle { get; set; }
        [DisplayName("estado")]
        string estado { get; set; }
        [DisplayName("ID Habitacion")]
        int ID { get; set; }
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