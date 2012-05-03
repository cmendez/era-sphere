using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.ApiConfiguracion.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.ApiConfiguracion.Models
{
    public class Cadena: DBable
    {
        public string nombreCadena { get; set; }
        public string rsocial { get; set; }
        public string ruc { get; set; }
        public string url { get; set; }
        public byte[] logo { get; set; }
        public decimal adel_minimo { get; set; }
        public int d_cancel_dps_reserva { get; set; }
        public int d_cancel_antes_chk_in { get; set; }
        public decimal porc_ret { get; set; }
        public decimal ptos_x_dolar { get; set; }
        public string hostname { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Cadena()
        { 
            
        }
        
}