using System;
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

        [Required]
        [StringLength(30)]
        [DisplayName("Descripcion")]
        public string detalle { get; set; }

        public int tipo_servicioID { get; set; }


        public ServicioView() { }

        public ServicioView(Servicio servicio)
        {
            ID = servicio.ID;
            detalle = servicio.descripcion;
            tipo_servicioID = servicio.tipo_servicioID; 
        }

        public Servicio deserializa(LogicaServicios logica)
        {
            return new Servicio
            {
                ID = this.ID,
                descripcion = this.detalle,
                tipo_servicioID = this.tipo_servicioID,
                tipo_servicio = logica.context.tipo_servicios.Find(this.tipo_servicioID),
            };

        }
    }
}