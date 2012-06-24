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
        public int ID { get; set; }

        [DisplayName("Piso")]
        public int pisoID { get; set; }
        [DisplayName("Piso")]
        public string piso_nombre { get; set; }

        [Required]
        [DisplayName("Tipo de habitacion")]
        public int tipoHabitacionID { get; set; }

        [Required]
        [DisplayName("Habitación")]
        [StringLength(50)]
        public string detalle { get; set; }

        [Required]
        [DisplayName("Estado")]
        public int estado_habitacionID { get; set; }

        public HabitacionView() { }
        public HabitacionView(Habitacion habitacion)
        {
            detalle = habitacion.detalle;
            ID = habitacion.ID;
            tipoHabitacionID = habitacion.tipoHabitacionID;
            estado_habitacionID = habitacion.estadoID;
            pisoID = habitacion.pisoID;
            piso_nombre = habitacion.piso.descripcion;
        }
        
        public Habitacion deserializa(LogicaHabitacion logica)
        {
            return new Habitacion
            {
                detalle = this.detalle,
                estadoID = this.estado_habitacionID,
                ID = this.ID,
                tipoHabitacionID = this.tipoHabitacionID,
                pisoID = this.pisoID,
                piso = logica.context.pisos.Find(this.pisoID),
                tipoHabitacion = logica.context.tipos_habitacion.Find(this.tipoHabitacionID),
                estado = logica.context.estado_espacio_rentable.Find(this.estado_habitacionID),
            };
        }

    }
}