using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class Adicional:DBable
    {
        
        public string nombre { get; set; }
        
        public decimal precio { get; set; }
        [ForeignKey("evento")]
        public int eventoID { get; set; }
        
        public virtual Era_sphere.Areas.AreaEventos.Models.Evento.Evento evento { get; set; }
    }
}