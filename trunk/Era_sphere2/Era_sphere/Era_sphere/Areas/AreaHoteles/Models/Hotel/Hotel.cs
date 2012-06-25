using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaConfiguracion.Models;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaEventos.Models.Evento;

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

        //public string provincia { get; set; }
        //[InverseProperty("hotel")]
        public virtual ICollection<Piso> lista_pisos { get; set; } 
       //public Ciudad ciudad { get; set; }
        public int ?paisID { get; set; }
        public virtual Pais pais { get; set; }
        public int? ciudadID { get; set; }
        public virtual Ciudad ciudad { get; set; }
        public int? provinciaID { get; set; }
        public virtual Provincia provincia { get; set; } 
        //public ICollection<Piso> pisos_hotel { get; set; }
        public virtual ICollection<TipoServicioXHotel> tiposerviciosxhoteles { get; set; }
        public virtual ICollection<Proveedor> proveedores { get; set; }
        public virtual ICollection<OrdenCompra> ordenes_compra { get; set; }
        
    }
}