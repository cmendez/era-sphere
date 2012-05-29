using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaPaquetes.Models
{
    public class PaqueteView
    {
        public PaqueteView() { }
        public PaqueteView(Paquete paquete)
        {
            ID = paquete.ID;
            nombre = paquete.nombre;
            puntos_requeridos = paquete.puntos_requeridos;
            fecha_inicio = paquete.fecha_inicio;
            fecha_fin = paquete.fecha_fin;
        }
        [Required]
        [MaxLength(30)]
        [DisplayName("nombre")]
        public string nombre { get; set; }
        [Required]
        public int puntos_requeridos { get; set; }
        [Required]
        public DateTime fecha_inicio { get; set; }
        [Required]
        public DateTime fecha_fin { get; set; }
        [DisplayName("ID Paquete")]
        [Required]
        public int ID { get; set; }
        public Paquete deserializa(InterfazLogicaPaquete logica)
        {
            return new Paquete
            {
                nombre=this.nombre,
                ID = this.ID,
                
            };
        }

    }
}