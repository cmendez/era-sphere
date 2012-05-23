using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HabitacionView
    {
        public HabitacionView() { }
        public HabitacionView(Habitacion habitacion)
        {
            detalle = habitacion.detalle;
            ID = habitacion.ID;
            tipoHabitacionID = habitacion.tipoHabitacionID;
            LogicaTipoHabitacion logica_tipo_habitacion = new LogicaTipoHabitacion();
            TipoHabitacionView tipo_habitacion_view = logica_tipo_habitacion.retornarTipoHabitacion(tipoHabitacionID);
            tipoHabitacion_descripcion = tipo_habitacion_view.descripcion;
            estado_habitacionID = habitacion.estado_habitacionID;
            
        }
        [DisplayName("Estado")]
        public int estado_habitacionID { get; set; }
        [DisplayName("Detalle")]
        public string detalle { get; set; }
        [DisplayName("ID Habitacion")]
        [Required]
        public int ID { get; set; }
        [DisplayName("ID Tipo de habitacion")]
        public int tipoHabitacionID { get; set; }
        [DisplayName("Tipo de habitacion")]
        public string tipoHabitacion_descripcion { get; set; }

        public Habitacion deserializa(InterfazLogicaHabitacion logica)
        {
            return new Habitacion
            {
                detalle = this.detalle,
                estado_habitacionID=this.estado_habitacionID,
                ID = this.ID,
                tipoHabitacionID=this.tipoHabitacionID 
                
            };
        }
        
    }
}