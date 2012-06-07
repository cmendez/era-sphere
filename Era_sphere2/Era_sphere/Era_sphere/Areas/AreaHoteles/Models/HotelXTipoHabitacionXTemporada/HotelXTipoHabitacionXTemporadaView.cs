﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Temporada;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models.HotelXTipoHabitacionXTemporadaNM
{
    public class HotelXTipoHabitacionXTemporadaView : IValidatableObject
    {
        public HotelXTipoHabitacionXTemporadaView()
        {
        }

        public HotelXTipoHabitacionXTemporadaView(int hotelID)
        {
            this.hotelID = hotelID;
        }

        public HotelXTipoHabitacionXTemporadaView(HotelXTipoHabitacionXTemporada hxthxt)
        {
            this.ID = hxthxt.ID;

            this.tipoHabitacion_descripcion = hxthxt.tipoHabitacion.descripcion;
            this.tt_desc = hxthxt.temporada.tipotemporada.descripcion;
            this.t_desc = hxthxt.temporada.descripcion;
            this.precio = hxthxt.precio;

            this.hotelID = hxthxt.hotelID;
            this.tipoHabitacionID = hxthxt.tipoHabitacionID;
            this.temporadaID = hxthxt.temporadaID;

            this.costo_base = hxthxt.tipoHabitacion.costo_base;
        }

        [Required]
        public int ID { get; set; }


        [Required]
        [DisplayName("Precio ($)")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.infinito)]
        public decimal precio { get; set; }



        [Required]
        public int hotelID { get; set; }
        [Required]
        [DisplayName("Tipo de habitacion")]
        public int tipoHabitacionID { get; set; }
        [Required]
        [DisplayName("Temporada")]
        public int temporadaID { get; set; }

        
        [DisplayName("TipoHabitacion")]
        public string tipoHabitacion_descripcion { get; set; }
        [DisplayName("Tipo de temporada")]
        public string tt_desc { get; set; }
        [DisplayName("Temporada")]
        public string t_desc { get; set; }

        public decimal costo_base { get; set; }



        public HotelXTipoHabitacionXTemporada deserializa()
        {
            return new HotelXTipoHabitacionXTemporada
            {
                ID = this.ID,
                hotelID = this.hotelID,
                tipoHabitacionID = this.tipoHabitacionID,
                temporadaID = this.temporadaID,
                precio = this.precio
            };
        }

        public bool isValid()
        {
            bool fieldsValid = (this.tipoHabitacionID != 0) && (this.temporadaID != 0) && (this.hotelID != 0);
            if (!fieldsValid) return false;
            bool precioValid = (new LogicaTipoHabitacion()).retornarTipoHabitacion2(this.tipoHabitacionID).costo_base <= this.precio;
            if (!precioValid) return false;
            return true;
        }


        public IEnumerable<ValidationResult>
           Validate(ValidationContext validationContext)
        {
            var field = new[] { "precio" };

            if (precio < (new EraSphereContext()).tipos_habitacion.Find(tipoHabitacionID).costo_base)
            {
                yield return new ValidationResult("El precio debe ser mayor al base", field);
            }
        }
    }
}