using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HotelView
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [DisplayName("Razon Social")]
        public string razon_social { get; set; }
        [DisplayName("Identificacion de Registro")]
        public string reg_id { get; set; }
        [DisplayName("Numero de Registro")]
        public string nroreg_id { get; set; }
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        [DisplayName("Telefono 1")]
        public string telefono_1 { get; set; }
        [DisplayName("Telefono 2")]
        public string telefono_2 { get; set; }
        [DisplayName("Fax ")]
        public string fax { get; set; }
        [DisplayName("Provincia")]
        public string provincia { get; set; }
       
        [DisplayName("Ciudad")]
        public int ciudad_id { get; set; }
    }
}