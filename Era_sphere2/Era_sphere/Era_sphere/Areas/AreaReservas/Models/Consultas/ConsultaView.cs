using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class ConsultaView
    {
        [Required]
        [DisplayName("Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [DisplayName("Fecha Fin")]
        public DateTime fecha_fin { get; set; }

        [DisplayName(@"Número de Piso")]
        public int pisoID { get; set; }

        [DisplayName(@"Tipo de Habitación")]
        public int tipo_habitacionID { get; set; }


        public int hotelID { get; set; }

        [DisplayName("Habitaciones Libres")]
        public int habitaciones_libres_total { get; set; }
        
        [DisplayName("Libres por Piso")]
        public int habitaciones_libres_piso { get; set; }

        [DisplayName("Libres por Tipo")]
        public int habitaciones_libres_tipo { get; set; }

        public List<ConsultaLineaView> resultados { get; set; }

        public ConsultaView(Consulta con)
        {
            fecha_fin = con.fecha_fin;
            fecha_inicio = con.fecha_inicio;
            pisoID = con.pisoID;
            hotelID = con.hotelID;
            tipo_habitacionID = con.tipo_habitacionID;
            habitaciones_libres_total = con.habitaciones_libres_total;
            habitaciones_libres_tipo = con.habitaciones_libres_tipo;
            habitaciones_libres_piso = con.habitaciones_libres_piso;
            resultados = new List<ConsultaLineaView>();
            foreach (Habitacion hab in con.habitaciones_resultantes)
                resultados.Add(new ConsultaLineaView { habitacionID = hab.ID, numero_habitacion = hab.detalle, tipo_habitacionID = hab.tipoHabitacionID });

        }
        public ConsultaView() { }
    }

}