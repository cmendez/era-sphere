using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaPaquetes.Models
{
    public class Paquete:DBable
    {
        public string nombre { get; set; }
        public int puntos_requeridos { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public ICollection<TipoHabitacion> lista_tiposHabitacion { get; set; }
    }
}