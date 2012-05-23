﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class TipoHabitacion: DBable
    {
        public int cap_max_personas { get; set; }
        public string descripcion { get; set; }
        public ICollection<Comodidad> comodidades { get; set; }
        public ICollection<Habitacion> lista_habitaciones { get; set; }
    }
}