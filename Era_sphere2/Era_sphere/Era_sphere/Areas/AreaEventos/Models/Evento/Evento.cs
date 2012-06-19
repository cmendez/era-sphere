﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class Evento:DBable
    {
        
        public string nombre { get; set; }
        
        public decimal precio_total { get; set; }
        
        public int num_participantes { get; set; }

        //[ForeignKey("hotel")]
        public int hotel { get; set; }
        //[Required]
        //public virtual Hotel hotel { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente.EventoXAmbiente> eventoXAmbiente { get; set; }

        public virtual ICollection<Era_sphere.Areas.AreaEventos.Models.Participante.Participante> participantes { get; set; }
        
        public int estado_eventoID { get; set; }
        
    }
}