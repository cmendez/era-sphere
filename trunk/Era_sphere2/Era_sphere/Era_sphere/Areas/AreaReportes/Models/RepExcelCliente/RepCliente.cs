using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaReportes.Models.RepExcelCliente
{
    public class RepCliente
    {
        public String fileName { get; set; }
        public String[,] cabecera { get; set; }
        public String[][] contenido { get; set; }
    }
}