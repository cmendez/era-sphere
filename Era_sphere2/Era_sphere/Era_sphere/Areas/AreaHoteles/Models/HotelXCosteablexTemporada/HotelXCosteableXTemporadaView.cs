using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXCosteableXTemporadaNM
{
    public class HotelXCosteableXTemporadaView
    {
        public HotelXCosteableXTemporadaView(HotelXCosteableXTemporada hxcxt)
        {
            this.ID = hxcxt.ID;
            this.costeable = hxcxt.costeable;
            this.temporada = hxcxt.temporada;
        }

        [Required]
        public int ID { get; set; }

        [Required]
        [DisplayName("Costeable")]
        public Costeable costeable { get; set; }

        [Required]
        [DisplayName("Temporada")]
        public Temporada temporada { get; set; }

        [Required]
        [DisplayName("Precio")] //EN QUE MONEDA!!!
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }

        public HotelXCosteableXTemporada deserializa()
        {
            return new HotelXCosteableXTemporada
            {
                ID = this.ID,
                costeable = this.costeable,
                temporada = this.temporada
            };
        }
    }
}