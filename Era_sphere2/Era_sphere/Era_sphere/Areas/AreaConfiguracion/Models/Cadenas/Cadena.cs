﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.AreaConfiguracion.Models;
using Era_sphere.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Cadenas
{

    public class Cadena : DBable
    {
        [MaxLength(30, ErrorMessage = "La longitud maxima es de 30 caracteres")]
        [Required(ErrorMessage = "El campo nombre de la cadena es obligatorio")]
        [DisplayName("Nombre de la cadena")]
        public string nombreCadena { get; set; }

        [MaxLength(30, ErrorMessage = "La longitud maxima es de 30 caracteres")]
        [Required(ErrorMessage = "El campo razón social es obligatorio")]
        [DisplayName("Razón social")]
        public string rsocial { get; set; }

        [MinLength(11, ErrorMessage = "El campo RUC debe estar compuesto por 11 digitos")]
        [MaxLength(11, ErrorMessage = "El campo RUC debe estar compuesto por 11 digitos")]
        [Required(ErrorMessage = "El campo RUC es obligatorio")]
        //[Range(11, 11, ErrorMessage = "El RUC debe ser contener 11 digitos")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El campo RUC debe estar compuesto por 11 digitos")]
        [DisplayName("RUC de la cadena")]
        public string ruc { get; set; }

        [MaxLength(30, ErrorMessage = "La longitud maxima es de 30 caracteres")]
        [Required(ErrorMessage = "El campo página web es obligatorio")]
        //[DataType(DataType.Url)] 
        //[DataType(DataType.Url, ErrorMessage = "Email invalido")]
        [RegularExpression("(http|https)://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?", ErrorMessage="Web invalida")]
        [DisplayName("Página web [Formato: http://pagina.com]")]
        public string url { get; set; }

        //[DisplayName("Logo")]
        public byte[] logo { get; set; }

        [DisplayName("Adelanto mínimo (%)")]
        [Range(0,100)]
        public decimal adel_minimo { get; set; }

        [DisplayName("Dias antes de check-in con retencion")]
        [Range(0, Generics.StringsDeValidaciones.infinito)]
        public int d_ant_ret { get; set; }

        [DisplayName("% retenido (del adelanto)")]
        [Range(0,100)]
        public decimal porc_ret { get; set; }

        [DisplayName("Puntos por dólar")]
        [Range(0,Era_sphere.Generics.StringsDeValidaciones.anho)]
        public int ptos_x_dolar { get; set; }

        [DisplayName("Hostname")]
        public string hostname { get; set; }

        [DisplayName("Port")]
        public string port { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }

        public Cadena()
        {

        }
    }
}