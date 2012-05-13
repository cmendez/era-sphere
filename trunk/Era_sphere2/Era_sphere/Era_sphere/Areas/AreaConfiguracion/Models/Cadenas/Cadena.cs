﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.Configuracion.Models;
using Era_sphere.Generics;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaConfiguracion.Models.Cadenas
{
    
    public class Cadena: DBable
    {
        [DisplayName("Nombre de la cadena")]
        public string nombreCadena { get; set; }

        [DisplayName("Razón social")]
        public string rsocial { get; set; }

        [DisplayName("RUC de la cadena")]
        public string ruc { get; set; }

        [DisplayName("Página web")]
        public string url { get; set; }

        //[DisplayName("Logo")]
        public byte[] logo { get; set; }

        [DisplayName("Adelanto mínimo")]
        public decimal adel_minimo { get; set; }

        [DisplayName("Depósito a cancelar después de la reserver")]
        public int d_cancel_dps_reserva { get; set; }

        [DisplayName("Depósito a cancelar antes del check in")]
        public int d_cancel_antes_chk_in { get; set; }

        [DisplayName("Porcentaje retenido")]
        public decimal porc_ret { get; set; }

        [DisplayName("Puntos por dólar")]
        public decimal ptos_x_dolar { get; set; }

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