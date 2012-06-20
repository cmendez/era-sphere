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
        //Este es el comprobante con el que se pago' esta boleta linea
        [ForeignKey("recibo")]
        public int reciboID { get; set; }
        public Recibo recibo { get; set; }

        public int? espacio_rentableID { get; set; }

        public decimal precio_unitario { get; set; }//

        [DisplayName("Detalle")]
        public string detalle { get; set; }//
       
        [DisplayName("Unidades")]
        public int unidades { get; set; }//
        public bool pagado { get; set; }//
        
        [DisplayName("Puntos")]
        public int puntos { get; set; }//
        
        [DisplayName("Fecha de la transaccion")]
        public DateTime fecha { get; set; }//

        public bool de_servicio { get; set; }
        public bool de_reserva { get; set; }
        public bool de_evento { get; set; }
        
        [DisplayName("Precio final")]
        public decimal precio_final { get { return precio_unitario * unidades; } }

        public ReciboLinea(string detalle, decimal precio_unitario, int Tipo, DateTime fecha, int unidades=1)
        {
            this.detalle = detalle;
            this.precio_unitario = precio_unitario;
            this.unidades = unidades;
            this.pagado = false;
            this.fecha = fecha;

            if (Tipo == 0) { this.de_servicio = true; this.de_reserva = false; this.de_evento = false ;}
            if (Tipo == 1) { this.de_servicio = false; this.de_reserva = true; this.de_evento = false ;}
            if (Tipo == 2) { this.de_servicio = false; this.de_reserva = false; this.de_evento = true ;}

        }

        public ReciboLinea() { }
    }
}