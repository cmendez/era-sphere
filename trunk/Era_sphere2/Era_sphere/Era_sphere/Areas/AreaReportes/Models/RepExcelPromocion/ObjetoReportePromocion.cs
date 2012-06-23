using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaReportes.Models.RepExcelPromocion
{
    public class ObjetoReportePromocion
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int puntos_requeridos { get; set; }
        public int descuento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        //public int relacionpromocionID { get; set; }
        public string relacionpromocion { get; set; }
    
        public ObjetoReportePromocion(string nombre, string descripcion, int puntos_requeridos, int descuento, DateTime fecha_inicio, DateTime fecha_fin, int relacionpromocionID)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.puntos_requeridos = puntos_requeridos;
            this.descuento = descuento;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
            //this.relacionpromocionID = relacionpromocionID;

            EraSphereContext context = new EraSphereContext();
            this.relacionpromocion = (context.relacionespromocion.Find(relacionpromocionID)).descripcion;
        }
    }
}