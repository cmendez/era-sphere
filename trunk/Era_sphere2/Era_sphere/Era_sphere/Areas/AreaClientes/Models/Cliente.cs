using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaContable.Models.Recibo;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaClientes.Models
{
    
        public class Cliente : Persona
        {
            [ForeignKey("estado")]
            public int estadoID { get; set; }
            public virtual EstadoCliente estado { get; set; }

            public string tarjeta_cliente { get; set; }

            public Habitacion habitacion_asignada { get; set; }
            public int id_habitacion_asisgnada { get; set; }
            public int puntos_cliente { get; set; }
            public int numero_reservas { get; set; }
            public virtual ICollection<Recibo> recibos_cliente { get; set; }

            [InversePropertyAttribute("responsable_pago")]
            public virtual ICollection<Reserva> reservas { get; set; }

            [InversePropertyAttribute("huespedes")]
            public virtual ICollection<HabitacionXReserva> habitacion_reservas { get; set; }
        }



}