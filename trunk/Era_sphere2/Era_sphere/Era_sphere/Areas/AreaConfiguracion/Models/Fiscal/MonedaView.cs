using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class MonedaView
    {
        public MonedaView() { }
        public MonedaView(Moneda moneda)
        {
            ID = moneda.ID;
            descripcion = moneda.descripcion;
            simbolo = moneda.simbolo;
            tc = moneda.tc;
        }
        [Required]
        [DisplayName("Descripcion")]
        [MaxLength(20)]
        public string descripcion { get; set; }
        [Required]
        [DisplayName("Símbolo")]
        [MaxLength(5)]
        public string simbolo { get; set; }
        [DisplayName("ID Moneda")]
        public int ID { get; set; }
        [DisplayName("Tipo de cambio (USD$)")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal? tc { get; set; } 

        public Moneda deserializa(InterfazLogicaMoneda logica)
        {
            return new Moneda
            {
                descripcion = this.descripcion,
                simbolo = this.simbolo,
                ID = this.ID,
                tc = this.tc
            };
        }
    }
}