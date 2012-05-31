using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaReservas.Models;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaCargos.Models;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class TipoServicio : DBable
    {
        public bool tiene_productos_asociados { get; set; }
        public bool tiene_hora { get; set; }
        public bool tiene_repeticiones { get; set; }
        
        public string nombre { get; set; }
        public string descripcion { get; set; }                
    }
}