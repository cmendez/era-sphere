using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class Reserva: DBable
    {
        public enum Estado
        {
            sin_checkIn,
            checkedIn,
            checkedOut,
            Anulada
        };

        public Estado estado;
        
        public DateTime check_in;
        public DateTime check_out;
        public decimal monto_inicial;
        public int num_habitaciones;

        public List<Cliente> List_huespedes; //huespedes asignados

    }
}