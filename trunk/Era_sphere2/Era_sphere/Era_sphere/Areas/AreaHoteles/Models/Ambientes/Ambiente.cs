using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class Ambiente: DBable
    {
        public string descripcion { get; set; }
        public int capacidad_maxima { get; set; }
        public int num_niveles { get; set; }
        public string detalle { get; set; }
        public decimal precio { get; set; }

        [ForeignKey("piso")]
        public int pisoID { get; set; }
        public virtual Piso piso { get; set; }

        [ForeignKey("estado")]
        public int estadoID { get; set; }
        public virtual EstadoEspacioRentable estado { get; set; }
    }
}