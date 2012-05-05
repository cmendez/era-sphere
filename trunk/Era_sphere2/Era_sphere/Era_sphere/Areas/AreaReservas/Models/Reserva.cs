using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaReservas.Models
{
    public class Reserva: DBable
    {
        public enum Estado
        {
            Sin checkIn,
            checkedIn,
            checkedOut,
            Anulada
        };

        public Estado estado;
        
        public DateTime check_in;
        public DateTime check_out;
        public decimal monto_inicial;
        public int num_habitaciones<hu;

        public List<         > List_huespedes; //huespedes asignados

    }
}