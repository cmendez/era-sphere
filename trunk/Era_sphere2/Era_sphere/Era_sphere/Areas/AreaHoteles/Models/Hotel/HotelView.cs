using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaHoteles.Models
{
    public class HotelView
    {

        public HotelView() { }
        public HotelView(Hotel hotel)
        {
            // TODO: Complete member initialization
            ID = hotel.ID;
            descripcion = hotel.descripcion;
            razon_social = hotel.razon_social;
            reg_id = hotel.reg_id;
            nroreg_id = hotel.nroreg_id;
            direccion = hotel.direccion;
            telefono_1 = hotel.telefono_1;
            telefono_2 = hotel.telefono_2;
            fax = hotel.fax;            
            paisID = hotel.paisID;
            ciudadID = hotel.ciudadID;
            provinciaID = hotel.provinciaID;

            pais_nombre = hotel.pais.nombre;
            ciudad_nombre = hotel.ciudad.nombre;
            provincia_nombre = hotel.provincia.nombre;
        }

        [Required]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }
        [Required]
        [DisplayName("Razon Social")]
        public string razon_social { get; set; }
        [Required]
        [DisplayName("Identificacion de Registro")]
        public string reg_id { get; set; }
        
        [Required]
        [DisplayName("Numero de Registro")]
        [RegularExpression(StringsDeValidaciones.numeric)]
        public string nroreg_id { get; set; }
        
        [Required]
        [DisplayName("Direccion")]
        public string direccion { get; set; }
        
        [Required, StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        [DisplayName("Telefono 1")]
        public string telefono_1 { get; set; }

        [StringLength(28)]
        [RegularExpression(StringsDeValidaciones.telefono)]
        [DisplayName("Telefono 2")]
        public string telefono_2 { get; set; }
        
        [StringLength(28)]
        [DisplayName("Fax")]
        [RegularExpression(StringsDeValidaciones.telefono)]
        public string fax { get; set; }

        [Required]
        [DisplayName("Pais")]
        public int paisID { get; set; }
        [Required]
        [DisplayName("Ciudad")]
        public int ciudadID { get; set; }
        [Required]
        [DisplayName("Provincia")]
        [DisplayFormat(NullDisplayText="No aplica")]
        public int? provinciaID { get; set; }

        [DisplayName("Pais")]
        public string pais_nombre { get; set; }
        [DisplayName("Ciudad")]
        public string ciudad_nombre { get; set; }
        [DisplayName("Provincia")]
        public string provincia_nombre { get; set; }


        public Hotel deserializa(InterfazLogicaHotel logica)
        {
            return new Hotel
            {
                // ciudad = logica.retornarCiudad(ciudad_id),
                descripcion = this.descripcion,
                direccion = this.direccion,
                fax = this.fax,
                ID = this.ID,
                nroreg_id = this.nroreg_id,
                razon_social = this.razon_social,
                reg_id = this.reg_id,
                telefono_1 = this.telefono_1,
                telefono_2 = this.telefono_2,
                paisID = this.paisID,
                ciudadID = this.ciudadID,
                provinciaID = this.provinciaID,
                pais = logica.context_publico.paises.Find(this.paisID),
                ciudad = logica.context_publico.ciudades.Find(this.ciudadID),
                provincia = logica.context_publico.provincias.Find(this.provinciaID)
            };
        }
    }
}