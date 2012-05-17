using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;


namespace Era_sphere.Areas.AreaReservas.Models
{
    public class Reserva: DBable
    {
        public enum Estado
        {

            Sin_checkIn,
            checkedIn,
            checkedOut,
            Anulada
        };

        [DisplayName("Estado")]
        public Estado estado { get; set; }

        [DisplayName("Día de Check In")]
        public DateTime? check_in { get; set; }

        [DisplayName("Día de Check Out")]
        public DateTime? check_out { get; set; }

        [DisplayName("Monto Inicial")]
        public decimal costo_inicial { get; set; }

        [DisplayName("Monto a cancelar")]
        public decimal precio_derecho_reserva { get; set; }

        [DisplayName("Número de habitaciones")]
        public int num_habitaciones { get; set; }

        //[DisplayName("Tarjeta cliente")]
        public ICollection<Cliente> lista_huespedes { get; set; } //huespedes asignados

        public ICollection<Habitacion> lista_habitaciones { get; set; }
        

        //[DisplayName("Tarjeta cliente")]
        public Cliente responsable_pago { get; set; }

       //[DisplayName("Tarjeta cliente")]
        public DateTime? dia_creacion { get; set; }

       //[DisplayName("Tarjeta cliente")]
        public decimal costo_final { get; set; }

        [DisplayName("Reserva N°")]
        public string codigo_reserva {get; set;}

        [DisplayName("Días de Estadía")]
        public int dias_estadia { get; set; }
    }
}