using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Servicios
{
    public class ProductEntry {
        public int unidades {get; set;}
        public int productoID {get; set;}
    }
    public class ServicioView
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Descripcion")]
        public string detalle { get; set; }

        [DisplayName("Tipo de servicio")]
        public int tipo_servicioID { get; set; }
        public DateTime? fecha_y_hora { get; set; }
        [DisplayName("Repeticiones")]
        public int repeticiones { get; set; }

        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public string campo3 { get; set; }

        public List<ProductEntry> productos { get; set; }
        [DisplayName("Si el es precio fijado")] 
        public bool es_precio_fijado { get; set; }
        [DisplayName("Precio fijado")]
        public decimal precio_fijado { get; set; }

        [DisplayName("Precio normal unitario")]
        public decimal precio_normal { get; set; }


        public int eventoID { get; set; }



        [DisplayName("Precio final")]
        public decimal precio_final { get; set; }

        [DisplayName("Habitacion")]
        public string lugar { get; set; }

        public ServicioView() { }

        public ServicioView(Servicio servicio)
        {
            ID = servicio.ID;
            detalle = servicio.descripcion;
            tipo_servicioID = servicio.tipo_servicioID;
            fecha_y_hora = servicio.fecha_y_hora;
            repeticiones = servicio.repeticiones;
            campo1 = servicio.campo1;
            campo2 = servicio.campo2;
            campo3 = servicio.campo3;
            es_precio_fijado = servicio.es_precio_fijado;
            precio_fijado = servicio.precio_fijado;
            precio_normal = servicio.precio_normal;
            
            eventoID = servicio.eventoID ?? -1;

            precio_final = servicio.precio_final;
            lugar = servicio.lugar;
        }

        public Servicio deserializa(LogicaServicios logica)
        {
            Servicio s =  new Servicio
            {
                ID = this.ID,
                descripcion = this.detalle,
                tipo_servicioID = this.tipo_servicioID,
                tipo_servicio = logica.context.tipo_servicios.Find(this.tipo_servicioID),
                fecha_y_hora = this.fecha_y_hora,
                repeticiones = this.repeticiones,
                campo1 = this.campo1,
                campo2 = this.campo2,
                campo3 = this.campo3,
                precio_fijado = this.precio_fijado,
                es_precio_fijado = this.es_precio_fijado,
                precio_normal = this.precio_normal,
                lugar = this.lugar,
            };
            if (eventoID > 0)
                s.eventoID = eventoID;
            else
                s.eventoID = null;
            return s;
        }
    }
}