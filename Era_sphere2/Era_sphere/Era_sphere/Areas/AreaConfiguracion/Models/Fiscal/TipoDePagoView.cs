using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class TipoDePagoView
    {
        public TipoDePagoView() { }
        public TipoDePagoView(TipoDePago tipodepago)
        {
            ID = tipodepago.ID;
            descripcion = tipodepago.descripcion;
        }
        [Required]
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("ID Tipo de Pago")]
        public int ID { get; set; }
        public TipoDePago deserializa(InterfazLogicaTipoDePago logica)
        {
            return new TipoDePago
            {
                descripcion = this.descripcion,
                ID = this.ID,
            };
        }
    }
}