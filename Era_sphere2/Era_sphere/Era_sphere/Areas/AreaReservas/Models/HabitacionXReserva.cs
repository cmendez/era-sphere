using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaReservas.Models.Consultas
{
    public class HabitacionXReserva: DBable
    {
        public HabitacionXReserva() { }
        public HabitacionXReserva(int reservaID, int habitacionID)
        {
            this.reservaID = reservaID;
            this.habitacionID = habitacionID;
            this.huespedes = new HashSet<Cliente>();
        }
        public int reservaID { get; set; }
        public int habitacionID { get; set; }
        public virtual ICollection<Cliente> huespedes { get; set; }
    }
}