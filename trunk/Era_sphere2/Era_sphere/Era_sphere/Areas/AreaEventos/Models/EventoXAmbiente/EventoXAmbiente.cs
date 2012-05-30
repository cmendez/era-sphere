using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class EventoXAmbiente:DBable
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public DateTime fecha_hora_inicio { get; set; }
        [Required]
        public DateTime fecha_hora_fin { get; set; }
    }
}