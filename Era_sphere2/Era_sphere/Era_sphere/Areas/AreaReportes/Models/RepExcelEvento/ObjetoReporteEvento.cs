using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Era_sphere.Areas.AreaReportes.Models.RepExcelEvento
{
    public class ObjetoReporteEvento
    {
        public DateTime fecha_inicio { get; set; }
        public string hotel { get; set; }
        public string evento { get; set; }
        public int numAmb { get; set; }
        public int numPart { get; set; }
        public int numServ { get; set; }
        public decimal precioTotal { get; set; }

        public ObjetoReporteEvento(DateTime fecha, string hotel, string evento, int numPart, int numAmb, int numServ, decimal precioTotal) {
            this.fecha_inicio = fecha_inicio;
            this.hotel = hotel;
            this.evento = evento;
            this.numAmb = numAmb;
            this.numPart = numPart;
            this.numServ = numServ;
            this.precioTotal = precioTotal;        
        }
    }
}