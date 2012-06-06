using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;


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

        //[DisplayName("Tarjeta cliente")
        public DateTime? dia_creacion { get; set; }

        //[DisplayName("Tarjeta cliente")]
        public decimal costo_final { get; set; }

  
        [DisplayName(@"Número de Reserva")]
        public int ID { get; set; }

        //       [DisplayName("Días de Estadía")]
        
    
    }
}