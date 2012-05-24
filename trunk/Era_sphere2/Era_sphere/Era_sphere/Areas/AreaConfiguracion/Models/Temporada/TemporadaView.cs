using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class TemporadaView
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [DisplayName("Fecha de fin")]
        public DateTime fecha_fin { get; set; }

        
        public TemporadaView() { }

        public TemporadaView(Temporada temporada)
        {
            // TODO: Complete member initialization
            ID = temporada.ID;
            descripcion = temporada.descripcion;
        }

        public Temporada deserializa(LogicaTemporada logica)
        {
            return new Temporada
            {
                ID = this.ID,         
                descripcion = this.descripcion,
                fecha_fin = this.fecha_fin,
                fecha_inicio = this.fecha_inicio,
            };

        }
    }
}