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

        [DisplayName(@"Estado Reserva")]
        public int estadoID { get; set; }
        //public ICollection<Cliente> lista_huespedes { get; set; } //huespedes asignados

        //public ICollection<Habitacion> lista_habitaciones { get; set; }

        //public ICollection<Comodidad> lista_comodidades { get; set; }

        //public ICollection<Servicio> lista_servicios { get; set; }


        //[DisplayName("Tarjeta cliente")]
        [DisplayName("Responsable Pago")]
        public string responsable_pago { get; set; }

        //este campo no se debe mostrar en la vista, es solo para fines internos
        public int responsable_pagoID { get; set; }

        //[DisplayName("Tarjeta cliente")
        public DateTime dia_creacion { get; set; }

        //[DisplayName("Tarjeta cliente")]
        public decimal costo_final { get; set; }

        public string documento_identidad { get; set; }
  
        [DisplayName(@"Número de Reserva")]
        public int ID { get; set; }


        //ultimos agregados: DUDA en caso no se pueda utilizar el mismo partial View que las consultaas
        public int hotelID { get; set; }

        [DisplayName(@"Número de pisos")]
        public int pisoID { get; set; }

        //       [DisplayName("Días de Estadía")]

        public ReservaView() { }

        public ReservaView(Reserva r)
        {
            responsable_pago = LogicaCliente.toString(r.responsable_pago);
            responsable_pagoID = r.responsable_pago.ID;
            documento_identidad = r.responsable_pago.tipoID == 1 ? r.responsable_pago.documento_identidad
                                                                 : r.responsable_pago.ruc;
            dia_creacion = r.dia_creacion;
            dias_estadia = r.dias_estadia;
            check_in = r.check_in;
            check_out = r.check_out;
            costo_inicial = r.costo_inicial;
            costo_final = r.costo_final;
            precio_derecho_reserva = r.precio_derecho_reserva;
            ID = r.ID;
            num_habitaciones = r.num_habitaciones;
            estadoID = r.estadoID;
            //ultimos
            hotelID = r.hotelID;
            pisoID = r.pisoID;
        }


 
        public Reserva deserializa(LogicaReserva logica_reserva)
        {
            this.hallaResponsable(logica_reserva);
            Reserva r = new Reserva
            {
                responsable_pagoID = this.responsable_pagoID,
                responsable_pago = logica_reserva.context.clientes.Find(this.responsable_pagoID),
                precio_derecho_reserva = this.precio_derecho_reserva,
                num_habitaciones = this.num_habitaciones,
                ID = this.ID,
                check_in = this.check_in,
                check_out = this.check_out,
                dias_estadia = this.dias_estadia,
                dia_creacion = this.dia_creacion,
                costo_inicial = this.costo_inicial,
                costo_final = this.costo_final,
                estadoID = this.estadoID,
                estado = logica_reserva.context.estados_reserva.Find(this.estadoID),
                hotelID=this.hotelID,
                pisoID = this.pisoID
                
            };

            return r;
        }


        

        public void hallaResponsable(LogicaReserva logica_reserva)
        {
            string tipo = responsable_pago.Substring(responsable_pago.LastIndexOf(',') + 2);
            string documento = responsable_pago.Substring(responsable_pago.LastIndexOf(' ') + 1);
            int tipo_persona, tipo_documentoID;
            if (tipo[0] == 'D') tipo_persona = tipo_documentoID = 1;
            else if(tipo[0] == 'P'){
                tipo_persona = 1;
                tipo_documentoID = 2; 
            }else{
                tipo_persona = 2;
                tipo_documentoID = 3;
            }
            this.documento_identidad = documento;
            
            if (tipo_persona ==1)
                responsable_pagoID = logica_reserva.context.clientes.First(c => c.tipoID == tipo_persona && c.documento_identidad == documento && c.tipo_documentoID == tipo_documentoID).ID;
            if (tipo_persona ==2)
                responsable_pagoID = logica_reserva.context.clientes.First(c => c.tipoID == tipo_persona && c.ruc ==documento).ID;
        
        }

    
    }
}