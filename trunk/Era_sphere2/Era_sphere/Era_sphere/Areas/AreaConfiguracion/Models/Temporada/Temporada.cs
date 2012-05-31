using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Temporada
{
    public class Temporada:DBable
    {
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [DisplayName("Fecha de fin")]
        public DateTime fecha_fin { get; set; }

        [DisplayName("Tipo de temporada")]
        public int tipotemporadaID { get; set; }
        public virtual TipoTemporada tipotemporada { get; set; }

    
    }
}