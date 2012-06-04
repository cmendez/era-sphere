using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class ComodidadView
    {
        public ComodidadView() { }
        public ComodidadView(Comodidad comodidad)
        {
            descripcion = comodidad.descripcion;
            ID = comodidad.ID;

        }
        [Required]
        [DisplayName("Descripcion")]
        [StringLength(30)]
        public string descripcion { get; set; }
        [DisplayName("ID comodidad")]
        public int ID { get; set; }

        public Comodidad deserializa()
        {

            return new Comodidad
            {
                descripcion = this.descripcion,
                ID = this.ID
            };

        }
    }
}