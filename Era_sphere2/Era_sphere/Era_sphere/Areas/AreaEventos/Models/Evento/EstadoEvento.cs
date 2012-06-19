using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class EstadoEvento : DBable
    {
        //public virtual ICollection<Evento> lista_evento { get; set; }
        public string descripcion { get; set; }
    }
    
}