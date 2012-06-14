using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class MonedaView : IValidatableObject
    {
        public MonedaView() 
        {
            ID = -1;
        }
        public MonedaView(Moneda moneda)
        {
            ID = moneda.ID;
            descripcion = moneda.descripcion;
            simbolo = moneda.simbolo;
            tc = moneda.tc;
            paisID = moneda.paisID;
            pais_str = (new EraSphereContext()).paises.Find(moneda.paisID).nombre;
        }

        public int ID { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [MaxLength(20)]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Símbolo")]
        [MaxLength(5)]
        public string simbolo { get; set; }

        [DisplayName("Tipo de cambio (con respecto al USD$)")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal tc { get; set; }

        [Required]
        [DisplayName("País de origen")]
        public int paisID { get; set; }
        [DisplayName("País de origen")]
        public string pais_str { get; set; }

        public Moneda deserializa(InterfazLogicaMoneda logica)
        {
            return new Moneda
            {
                descripcion = this.descripcion,
                simbolo = this.simbolo,
                ID = this.ID,
                tc = this.tc,
                paisID = this.paisID
            };
        }

        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field1 = new[] { "descripcion" };
            var field2 = new[] { "simbolo" };

            //var page = (System.Web.UI.Page)System.Web.HttpContext.Current.CurrentHandler;
            //string action = page.RouteData.Values["action"].ToString();

            string action = this.ID == -1 ? "Insert" : "Edit";

            int nrep1 = (new EraSphereContext()).monedas.Count(m => m.descripcion == this.descripcion);
            int nrep2 = (new EraSphereContext()).monedas.Count(m => m.simbolo == this.simbolo);

            if (1 <= nrep1 && action != "Edit")
            {
                yield return new ValidationResult("Ya existe una moneda con esta descripción", field1);
            }
            if (1 <= nrep2 && action != "Edit")
            {
                yield return new ValidationResult("Ya existe una moneda con este símbolo", field2);
            }
        }
    }
}