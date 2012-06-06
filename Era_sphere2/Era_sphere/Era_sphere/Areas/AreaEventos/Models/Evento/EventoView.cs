using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaEventos.Models.Evento
{
    public class EventoView
    {
        public EventoView() { }
        public EventoView(Evento evento)
        {
            ID = evento.ID;
            nombre = evento.nombre;
            precio_total = evento.precio_total;
            num_participantes = evento.num_participantes;
            //idHotel = evento.hotelID;
        }
        [Required]
        [MaxLength(30)]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        [Required]
        //falta limite
        [DisplayName("Precio")]
        public decimal precio_total { get; set; }
        [Required]
        //falta limite
        [DisplayName("Cantidad de participantes")]
        public int num_participantes { get; set; }
        [DisplayName("ID evento")]
        [Required]
        public int ID { get; set; }
        //[DisplayName("ID hotel")]
        //[Required]
        //public int idHotel { get; set; }
        public Evento deserializa()
        {
            return new Evento
            {
                ID=this.ID,
                nombre=this.nombre,
                precio_total=this.precio_total,
                num_participantes=this.num_participantes,
              //  hotelID=this.idHotel
            };
        }

    }
}