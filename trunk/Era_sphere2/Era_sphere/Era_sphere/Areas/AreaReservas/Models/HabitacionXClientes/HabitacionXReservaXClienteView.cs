using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaReservas.Models.Consultas;
using Era_sphere.Areas.AreaClientes.Models;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class HabitacionXReservaXClienteView
    {

        //public List<Cliente> huespedes_reserva { get; set; }
        //public virtual ICollection<HabitacionXReserva> habitaciones_reserva { get; set; }

        [DisplayName("Número de camas")]
        public int numero_camas { get; set; }

        [DisplayName("Capacidad")]
        public int huespedes_actuales { get; set; }
       
        [DisplayName(@"Número de Reserva")]
        public int reservaID { get; set; }

        public List<HabitacionXReservaXClienteLineaView> lista_clientes_habitacion { get; set; }

     public HabitacionXReservaXClienteView(int reservaID, List<HabitacionXReservaXClienteLineaView> hab_reserva_cliente)
        {
            this.reservaID = reservaID;
            this.lista_clientes_habitacion = hab_reserva_cliente;
                   
        }

  
    
    
    
    }
}