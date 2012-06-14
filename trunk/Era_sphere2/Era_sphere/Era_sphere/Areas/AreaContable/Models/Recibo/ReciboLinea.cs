using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Era_sphere.Generics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Era_sphere.Areas.AreaContable.Models.Recibo
{
    public class ReciboLinea: DBable
    {
        [ForeignKey("recibo")]
        public int reciboID { get; set; }
        public Recibo recibo { get; set; }

        public int? espacio_rentableID { get; set; }

        public decimal precio_unitario { get; set; }

        [DisplayName("Detalle")]
        public string detalle { get; set; }
        [DisplayName("Unidades")]
        public int unidades { get; set; }
        public bool pagado { get; set; }
        public DateTime fecha { get; set; }
        [DisplayName("Puntos")]
        public int puntos { get; set; }
        public bool de_servicio { get; set; }
        [DisplayName("Precio final")]
        public decimal precio_final { get { return precio_unitario * unidades; } }

        public ReciboLinea(string detalle, decimal precio_unitario, int unidades = 1)
        {
            this.detalle = detalle;
            this.precio_unitario = precio_unitario;
            this.unidades = unidades;
            this.pagado = false;
        }
        public ReciboLinea() { }
    }
}