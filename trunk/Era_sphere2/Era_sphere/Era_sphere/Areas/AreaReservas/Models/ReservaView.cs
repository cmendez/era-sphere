using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaReservas.Models;


namespace Era_sphere.Areas.AreaReservas
{
    public class ReservaView
    {
        [DisplayName(@"Día de Check In")]
        public DateTime? check_in { get; set; }

        [DisplayName(@"Día de Check Out")]
        public DateTime? check_out { get; set; }

        [DisplayName(@"Monto inicial")]
        public decimal costo_inicial { get; set; }

        [DisplayName(@"Monto a cancelar")]
        public decimal precio_derecho_reserva { get; set; }

        [DisplayName(@"Días de Estadía")]
        public int dias_estadia { get; set; }

        [DisplayName(@"Número de Habitaciones")]
        public int num_habitaciones { get; set; }

        public ICollection<Cliente> lista_huespedes { get; set; } //huespedes asignados

        public ICollection<Habitacion> lista_habitaciones { get; set; }

        public ICollection<Comodidad> lista_comodidades { get; set; }

        public ICollection<Servicio> lista_servicios { get; set; }


        //[DisplayName("Tarjeta cliente")]
        [DisplayName("Responsable Pago")]
        public string responsable_pago { get; set; }

        //este campo no se debe mostrar en la vista, es solo para fines internos
        public int responsable_pagoID { get; set; }

        //[DisplayName("Tarjeta cliente")
        public DateTime? dia_creacion { get; set; }

        //[DisplayName("Tarjeta cliente")]
        public decimal costo_final { get; set; }

        public string documento_identidad { get; set; }
  
        [DisplayName(@"Número de Reserva")]
        public int ID { get; set; }

        //       [DisplayName("Días de Estadía")]

        public void hallaResponsable(LogicaReserva logica_reserva)
        {
            string doc = responsable_pago.Substring(responsable_pago.LastIndexOf(' ') + 1);
            int tipo_persona;
            if (doc[0] == 'D') tipo_persona = 1; //natural
            else tipo_persona = 2; //juridico
            string documento = doc.Substring(1);
            this.documento_identidad = documento;
            responsable_pagoID = logica_reserva.context.clientes.First(c => c.tipoID == tipo_persona && c.documento_identidad == documento).ID;
        }

        public Reserva deserializa(LogicaReserva logica_reserva)
        {
            this.hallaResponsable(logica_reserva);
            Reserva r = new Reserva
            {
                responsable_pagoID = this.responsable_pagoID,
                responsable_pago = logica_reserva.context.clientes.Find(this.responsable_pagoID),
            };

            return r;
        }

        public ReservaView(Reserva r)
        {
            this.responsable_pago = LogicaCliente.toString(r.responsable_pago);
            this.responsable_pagoID = r.responsable_pago.ID;
            this.documento_identidad = r.responsable_pago.documento_identidad;
        }
        public ReservaView() { }
    
    }
}