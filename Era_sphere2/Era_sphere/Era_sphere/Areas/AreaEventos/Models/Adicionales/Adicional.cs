using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class Adicional:DBable
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public decimal precio { get; set; }
        [ForeignKey("evento")]
        public int eventoID { get; set; }
        [Required]
        public virtual Era_sphere.Areas.AreaEventos.Models.Evento.Evento evento { get; set; }
    }
}