using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Models
{
    public class LineaProductoView : IValidatableObject
    {

        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        
        public LineaProductoView() { }

        public LineaProductoView(LineaProducto lineaproducto)
        {
            // TODO: Complete member initialization
            ID = lineaproducto.ID;
            descripcion = lineaproducto.descripcion;
        }

        public LineaProducto deserializa(LogicaLineaProducto logica)
        {
            return new LineaProducto
            {
                ID = this.ID,         
                descripcion = this.descripcion,
            };

        }

        public IEnumerable<ValidationResult>
            Validate(ValidationContext validationContext)
        {
            var field = new[] { "descripcion" };
            //var field2 = new[] { "tipoHabitacionID" };

            int nr = (new EraSphereContext()).lineasproducto.Count(lp => lp.descripcion == descripcion);

            if (1 <= nr )
            {
                yield return new ValidationResult("Ya existe una linea de producto con ese nombre", field);
            }

        }


    }
}