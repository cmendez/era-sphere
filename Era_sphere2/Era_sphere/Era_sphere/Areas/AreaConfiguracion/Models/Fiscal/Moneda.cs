using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Fiscal
{
    public class Moneda : DBable
    {
        public string descripcion { get; set; }
        public string simbolo { get; set; }
        public decimal? tc { get; set; }
        [ForeignKey("paisOrigen")]
        public int? paisID { get; set; }


        public virtual Pais paisOrigen { get; set; }
    }
}