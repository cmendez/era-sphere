using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXPreciableXTemporadaNM
{
    public class HotelXPreciableXTemporadaView
    {
        public HotelXPreciableXTemporadaView()
        {
        }

        public HotelXPreciableXTemporadaView(HotelXPreciableXTemporada hxpxt)
        {
            this.ID = hxpxt.ID;
            this.preciable_descripcion = hxpxt.preciable.descripcion;
            this.tt_desc = hxpxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxpxt.temporada.descripcion;


            this.hotelID = hxpxt.hotelID;
            this.preciableID = hxpxt.preciableID;
            this.temporadaID = hxpxt.temporadaID;
        }

        [Required]
        public int ID { get; set; }

        [Required]
        [DisplayName("Preciable")]
        public string preciable_descripcion { get; set; }

        [Required]
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }

        [Required]
        [DisplayName("Temporada")]
        public string t_desc { get; set; }

        [Required]
        [DisplayName("Precio")] //dolares
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }




        private int hotelID;
        private int preciableID;
        private int temporadaID;



        public HotelXPreciableXTemporada deserializa()
        {
            return new HotelXPreciableXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                preciableID = this.preciableID,
                temporadaID = this.temporadaID
            };
        }
    }
}