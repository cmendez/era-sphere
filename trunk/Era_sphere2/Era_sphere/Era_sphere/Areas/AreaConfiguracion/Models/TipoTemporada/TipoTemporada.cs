using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.TipoTemporada
{
    public class TipoTemporada:DBable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
    }
}