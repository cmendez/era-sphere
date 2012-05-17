using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models.Piso
{
    public class PisoView
    {
        public PisoView() { }
        public PisoView(Piso piso)
        {
            descripcion = piso.descripcion;
            ID = piso.ID;
            hotel_id = piso.hotel.ID;
            hotel_descripcion = piso.hotel.descripcion;
        }
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("Nombre del hotel")]
        public string hotel_descripcion { get; set; }
        [DisplayName("ID piso")]
        public int ID { get; set; }
        [DisplayName("ID Hotel")]
        public int hotel_id { get; set; }

    }
}