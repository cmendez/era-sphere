using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_App.Areas.ApiCliente.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
    }
}