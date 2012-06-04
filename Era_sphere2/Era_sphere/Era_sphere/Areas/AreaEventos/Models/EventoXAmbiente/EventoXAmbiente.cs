using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class EventoXAmbiente:DBable
    {

        public int hotelID;
        [Required]
        public string nombre { get; set; }
        [Required]
        public DateTime fecha_hora_inicio { get; set; }
        [Required]
        public DateTime fecha_hora_fin { get; set; }

        //nose si falta precio

        [Key, Column(Order = 1, TypeName = "int")]
        [ForeignKey("evento")]
        public int eventoID { get; set; }
        public Era_sphere.Areas.AreaEventos.Models.Evento.Evento evento { get; set; }

        [Key, Column(Order = 2, TypeName = "int")]
        [ForeignKey("ambiente")]
        public int ambienteID { get; set; }
        public Ambiente ambiente { get; set; }
    }
    
}