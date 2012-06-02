using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class Servicio : DBable
    {
        public string descripcion { get; set; }

        [ForeignKey("tipo_servicio")]
        public int? tipo_servicioID { get; set; }
        public TipoServicio tipo_servicio { get; set; }

        public ICollection<Producto> productos { get; set; }
        public ICollection<int> cantidades { get; set; }

        public DateTime? fecha { get; set; }
        public int hora { get; set; }
        public int repeticiones { get; set; }

        [ForeignKey("espacio_rentable")]
        public int? espacio_rentableID { get; set; }
        public EspacioRentable espacio_rentable { get; set; }

        
        public List<ReciboLinea> generarReciboLineas()
        {
            return null;
        }
    }
}