using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Era_sphere.Areas.AreaPromociones.Models
{
    public class PromocionView
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        
        public PromocionView() { }

        public PromocionView(Promocion promocion)
        {
            // TODO: Complete member initialization
            ID = promocion.ID;
            descripcion = promocion.descripcion;
        }

        public Promocion deserializa(LogicaPromocion logica)
        {
            return new Promocion
            {
                ID = this.ID,         
                descripcion = this.descripcion,
            };

        }


    }
}