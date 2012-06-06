using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;


namespace Era_sphere.Areas.AreaEventos.Models.Participante
{
    public class Participante:DBable
    {
        public string nombre { get; set; }
        
        public string dni { get; set; }

        [ForeignKey("evento")]
        public int eventoID { get; set; }
        public virtual Era_sphere.Areas.AreaEventos.Models.Evento.Evento evento { get; set; }
    }
}