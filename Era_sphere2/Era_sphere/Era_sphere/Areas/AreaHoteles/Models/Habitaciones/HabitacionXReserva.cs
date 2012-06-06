using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaReservas.Models;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaHoteles.Models.Habitaciones
{
    public class HabitacionXReserva
    {
        public HabitacionXReserva()
        {
            huespedes = new HashSet<Cliente>();
            servicios = new HashSet<Servicio>();
        }
        [Key, Column(Order = 1)]
        public int habitacionID { get; set; }
        
        [Key, Column(Order = 2)]
        public int reservaID { get; set; }

        [InversePropertyAttribute("habitacion_reservas")]
        public virtual ICollection<Cliente> huespedes { get; set; }

        [InversePropertyAttribute("habitacion_reservas")]
        public virtual ICollection<Servicio> servicios { get; set; }

    }
}