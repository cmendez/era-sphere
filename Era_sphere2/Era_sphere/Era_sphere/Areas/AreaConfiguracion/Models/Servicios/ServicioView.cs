﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class ServicioView
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Descripcion")]
        public string detalle { get; set; }


        public ServicioView() { }

        public ServicioView(Servicio servicio)
        {
            ID = servicio.ID;
            detalle = servicio.tipo_servicio.descripcion;
        }

        public Servicio deserializa()
        {
            return new Servicio
            {
                ID = this.ID,
            };

        }
    }
}