using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Areas.AreaReservas.Models.Consultas;
using Era_sphere.Areas.AreaClientes.Models;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class HabitacionXReservaXClienteLineaView 
    {

        //[DisplayName("Nombres")]
        //public string nombre_cliente { get; set; }

        //[DisplayName("Apellido Paterno")]
        //public string apellido_paterno_cliente { get; set; }

        //[DisplayName("Apellido Materno")]
        //public string apellido_materno_cliente { get; set; }

        public int clienteID { get; set; }


        [DisplayName(@"Habitación")]
        public int habitacionID { get; set; }

        public HabitacionXReservaXClienteLineaView(int clienteID, int habitacionID)
        {
            this.clienteID = clienteID;
            this.habitacionID = habitacionID;
        }

        public HabitacionXReservaXClienteLineaView()
        {
        }
        
    
    }
}