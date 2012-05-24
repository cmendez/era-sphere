using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaConfiguracion.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Hotel : DBable
    {

        public string descripcion { get; set; }

        public string razon_social { get; set; }
  
        public string reg_id { get; set; }

        public string nroreg_id { get; set; }
 
        public string direccion { get; set; }

        public string telefono_1 { get; set; }
    
        public string telefono_2 { get; set; }
       
        public string fax { get; set; }

        public string provincia { get; set; }
        //[InverseProperty("hotel")]
        public virtual ICollection<Piso> lista_pisos { get; set; } 

       //public Ciudad ciudad { get; set; }
       // public Pais pais { get; set; }
       // public List<Piso> pisos_hotel { get; set; }
    }
}