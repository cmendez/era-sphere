using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Piso:DBable
    {
        public virtual ICollection<Ambiente> lista_ambientes { get; set; }
        public virtual ICollection<Habitacion> lista_habitaciones { get; set; }
        public string descripcion { get; set; }
        public string codigo_piso { get; set; }
        [Required]
        [ForeignKey("hotel")]
        public int hotelID { get; set; }
        public virtual Hotel hotel { get; set; }

        public string cod_con_descripcion
        {
            get
            {
                return codigo_piso + " - " + descripcion;
            }
        }
    }
}