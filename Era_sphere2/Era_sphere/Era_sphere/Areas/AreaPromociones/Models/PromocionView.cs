using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;


namespace Era_sphere.Areas.AreaPromociones.Models
{
    public class PromocionView : IValidatableObject
    {
        public int ID { get; set; }

        [Required, StringLength(30)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required, StringLength(50)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required]
        [DisplayName("Puntos requeridos")]
        public int puntos_requeridos { get; set; }

        [Required]
        [DisplayName("Descuento(%)")]
        public int descuento { get; set; }

        [Required]
        [DisplayName("Fecha de inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [DisplayName("Fecha de fin")]
        public DateTime fecha_fin { get; set; }

        [Required]
        [DisplayName("Asociado a")]
        public int relacionpromocionID { get; set; }
        //[DisplayName("Relación de la promoción")]
        public string relacionpromocion_descripcion { get; set; }



        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field = new[] { "fecha_inicio"};
            var field2 = new[] { "fecha_fin" };

            if (fecha_inicio < DateTime.Now)
            {
                yield return new ValidationResult("La fecha de inicio debe ser mayor que la fecha actual.", field);
            }

            if (fecha_fin < fecha_inicio)
            {
                yield return new ValidationResult("la fecha de fin debe ser mayor que la fecha de inicio", field2);
            }
        }




        public PromocionView() { }

        public PromocionView(Promocion promocion)
        {
            // TODO: Complete member initialization
            ID = promocion.ID;
            nombre = promocion.nombre;
            descripcion = promocion.descripcion;
            puntos_requeridos = promocion.puntos_requeridos;
            descuento = promocion.descuento;
            fecha_inicio = promocion.fecha_inicio;
            fecha_fin = promocion.fecha_fin;
            relacionpromocionID = promocion.relacionpromocionID;
        }

        public Promocion deserializa(LogicaPromocion logica)
        {
            return new Promocion
            {
                ID = this.ID,
                nombre = this.nombre,
                descripcion = this.descripcion,
                puntos_requeridos = this.puntos_requeridos,
                descuento = this.descuento,
                fecha_inicio = this.fecha_inicio,
                fecha_fin = this.fecha_fin,
                relacionpromocionID = this.relacionpromocionID,
                relacionpromocion = logica.promocion_context.relacionespromocion.Find(relacionpromocionID)
            };

        }


    }
}