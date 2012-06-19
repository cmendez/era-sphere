using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;

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
            Hotel = evento.hotel;
            estadoID = evento.estado_eventoID;
            detalle = evento.detalle;
            
            int pos=detalle.IndexOf(':');
            int natural=detalle.IndexOf("DNI");
            int pos2 = detalle.IndexOf(',');
            dni = detalle.Substring(pos+1) ;
            cliente_nombre = detalle.Substring(0,pos2);
            
            //List<Cliente> c = (new LogicaCliente()).retornarClientes().Where(e => e.documento_identidad == dni ).ToList();
            //if (c.Count > 0)
            //    clienteID = c.ElementAt(0).ID;
            //else
            //{
            //    c = (new LogicaCliente()).retornarClientes().Where(e => e.ruc == dni).ToList();
            //    clienteID = c.ElementAt(0).ID;
            //}
            //List<Cliente> c=(new LogicaCliente()).retornarClientes().Where(e => e.documento_identidad == dni || e.ruc==dni).ToList();
            //Cliente cliente = (new EraSphereContext()).clientes.Find(clienteID);
            //cliente_nombre = cliente.nombre;
            //cliente_apellido = cliente.apellido_paterno + " " + cliente.apellido_materno;
            //cliente_nombre = evento.cliente_reserva.nombre;
            //cliente_apellido = evento.cliente_reserva.apellido_materno;
        }
        public string dni { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Precio total")]
        public decimal precio_total { get; set; }
        [DisplayName("Cliente")]
        public string cliente_nombre { get; set; }
        [DisplayName("Apellidos")]
        public string cliente_apellido { get; set; }
        [DisplayName("detalle")]
        public string detalle { get; set; }
        
        [Required]
        //falta limite
        [DisplayName("Cantidad de participantes")]
        [Range(1, 1000)]
        public int num_participantes { get; set; }
        [DisplayName("ID evento")]
        [Required]
        public int ID { get; set; }
        [DisplayName("ID hotel")]
        public int estadoID { get; set; }
        //[Required]
        public int Hotel { get; set; }
        public Evento deserializa()
        {

            return new Evento
            {
                ID=this.ID,
                nombre=this.nombre,
                precio_total=this.precio_total,
                num_participantes=this.num_participantes,
                hotel=this.Hotel,
                estado_eventoID=this.estadoID,
                detalle=this.detalle,
                dni=this.dni,
            };
        }

    }
}