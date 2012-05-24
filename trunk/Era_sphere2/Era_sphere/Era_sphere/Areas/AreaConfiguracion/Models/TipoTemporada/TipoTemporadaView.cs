using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class TipoTemporadaView
    {

        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        
        public TipoTemporadaView() { }

        public TipoTemporadaView(TipoTemporada tipotemporada)
        {
            // TODO: Complete member initialization
            ID = tipotemporada.ID;
            descripcion = tipotemporada.descripcion;
        }

        public TipoTemporada deserializa(LogicaTipoTemporada logica)
        {
            return new TipoTemporada
            {
                ID = this.ID,         
                descripcion = this.descripcion,
            };

        }


    }
}