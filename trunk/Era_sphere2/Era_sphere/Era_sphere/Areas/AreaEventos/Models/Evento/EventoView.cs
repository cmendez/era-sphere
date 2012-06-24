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
            string tipo = evento.detalle.Substring(evento.detalle.LastIndexOf(',') + 2);
            string documento = evento.detalle.Substring(evento.detalle.LastIndexOf(' ') + 1);
            int tipo_persona, tipo_documentoID;
            if (tipo[0] == 'D') tipo_persona = tipo_documentoID = 1;
            else if (tipo[0] == 'P')
            {
                tipo_persona = 1;
                tipo_documentoID = 2;
            }
            else
            {
                tipo_persona = 2;
                tipo_documentoID = 3;
            }
            //this.documento = documento;

            if (tipo_persona == 1)
                clienteID = (new EraSphereContext()).clientes.First(c => c.tipoID == tipo_persona && c.documento_identidad == documento && c.tipo_documentoID == tipo_documentoID).ID;
            if (tipo_persona == 2)
                clienteID = (new EraSphereContext()).clientes.First(c => c.tipoID == tipo_persona && c.ruc == documento).ID;

            //
            
            ID = evento.ID;
            nombre = evento.nombre;
            precio_total = evento.precio_total;
            num_participantes = evento.num_participantes;
            Hotel = evento.hotel;
            estadoID = evento.estado_eventoID;
            pagado = evento.pagado;
            detalle = evento.detalle;
            
            int pos=detalle.IndexOf(':');
            int natural=detalle.IndexOf("DNI");
            int pos2 = detalle.IndexOf(',');
            dni = detalle.Substring(pos+1) ;
            cliente_nombre = detalle.Substring(0,pos2);
            fecha_inicio = evento.fecha_inicio;
            deuda = evento.precio_total - evento.pagado;
        }

        public int clienteID { get; set; }
        [Required]
        [DisplayName("Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }
        public decimal pagado { get; set; }
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
        [DisplayName("Deuda")]
        public decimal deuda { get; set; }
        
        //falta limite
        [DisplayName("Cantidad de participantes")]
        
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
                fecha_inicio=this.fecha_inicio,
                pagado=this.pagado
            };
        }

    }
}