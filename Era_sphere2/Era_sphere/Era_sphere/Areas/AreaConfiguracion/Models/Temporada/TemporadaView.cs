using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class TemporadaView:IValidatableObject
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [DisplayName("Fecha de fin")]
        public DateTime fecha_fin { get; set; }

        [Required]
        [DisplayName("ID Tipo de temporada")]
        public int tipotemporadaID { get; set; }
        [DisplayName("Tipo de temporada")]
        public string tipotemporada_descripcion { get; set; }

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field = new[] { "fecha_inicio", "fecha_fin" };

            if (fecha_inicio < DateTime.Now)
            {
                yield return new ValidationResult("La fecha de inicio debe ser mayor que la fecha actual.", field);
            }

            if (fecha_fin < fecha_inicio) 
            {
                yield return new ValidationResult("la fecha de fin debe ser mayor que la fecha de inicio", field);    
            }
        }


        
        public TemporadaView() { }

        public TemporadaView(Temporada temporada)
        {
            // TODO: Complete member initialization
            ID = temporada.ID;
            descripcion = temporada.descripcion;
            
            //
            tipotemporadaID = temporada.tipotemporadaID;
            fecha_inicio = temporada.fecha_inicio;
            fecha_fin = temporada.fecha_fin;
            LogicaTipoTemporada logica_tipo_temporada = new LogicaTipoTemporada();
            TipoTemporadaView tipo_temporada_view = logica_tipo_temporada.retornarTipoTemporada(tipotemporadaID);
            tipotemporada_descripcion = tipo_temporada_view.descripcion;
        }

        public Temporada deserializa(LogicaTemporada logica)
        {
            return new Temporada
            {
                ID = this.ID,         
                descripcion = this.descripcion,
                fecha_fin = this.fecha_fin,
                fecha_inicio = this.fecha_inicio,
                tipotemporadaID = this.tipotemporadaID,
            };

        }
    }
}