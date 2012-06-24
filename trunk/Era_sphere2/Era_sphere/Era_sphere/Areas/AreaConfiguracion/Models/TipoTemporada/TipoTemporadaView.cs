using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class TipoTemporadaView : IValidatableObject
    {

        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        
        public TipoTemporadaView() 
        {
            ID = -1;
        }

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

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field_desc = new[] { "descripcion" };

            int n_duplicados = (new LogicaTipoTemporada()).retornarDuplicados(this.descripcion);

            if (1 <= n_duplicados)
            {
                yield return new ValidationResult("Ya existe un tipo de temporada con esta descripción", field_desc);
            }
        }


    }
}