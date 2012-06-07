using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente
{
    public class EventoXAmbienteView
    {
        public EventoXAmbienteView() { }

        public EventoXAmbienteView(EventoXAmbiente eventoxambiente)
        {
            this.ID = eventoxambiente.ID;
            this.fecha_hora_fin = eventoxambiente.fecha_hora_fin;
            this.nombre = eventoxambiente.nombre;
            this.fecha_hora_inicio = eventoxambiente.fecha_hora_inicio;
            this.eventoID = eventoxambiente.eventoID;
            this.ev_nombre = eventoxambiente.evento.nombre;
            this.ev_precio_total = eventoxambiente.evento.precio_total;
            this.ev_num_participantes = eventoxambiente.evento.num_participantes;
            this.ambienteID = eventoxambiente.ambienteID;
            this.amb_capacidad_maxima = eventoxambiente.ambiente.capacidad_maxima;
            this.amb_descripcion = eventoxambiente.ambiente.descripcion;
            this.amb_detalle = eventoxambiente.ambiente.detalle;
            this.amb_num_niveles = eventoxambiente.ambiente.num_niveles;
            this.precio = eventoxambiente.precio;
            //this.hotelID = eventoxambiente.evento.hotelID;
        }

        public int ID { set; get; }

        public int eventoID { get; set; }

        public int ambienteID { get; set; }

        public string ev_nombre { get; set; }

        public decimal ev_precio_total { get; set; }

        public int ev_num_participantes { get; set; }

        public string amb_descripcion { get; set; }

        public int amb_capacidad_maxima { get; set; }

        public int amb_num_niveles { get; set; }

        public string amb_detalle { get; set; }

        public string nombre { get; set; }

        public DateTime fecha_hora_inicio { get; set; }

        public DateTime fecha_hora_fin { get; set; }

        public decimal precio { get; set; }
        


        public EventoXAmbiente deserializa()
        {
            return new EventoXAmbiente
            {
                ID = this.ID,
                nombre = this.nombre,
                fecha_hora_inicio = this.fecha_hora_inicio,
                fecha_hora_fin = this.fecha_hora_fin,
                eventoID = this.eventoID,
                ambienteID = this.ambienteID,
                precio=this.precio
            };
        }
    }
}