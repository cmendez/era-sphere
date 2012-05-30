using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class Evento:DBable
    {
        
        public string nombre { get; set; }
        
        public decimal precio_total { get; set; }
        
        public int num_participantes { get; set; }
    }
}