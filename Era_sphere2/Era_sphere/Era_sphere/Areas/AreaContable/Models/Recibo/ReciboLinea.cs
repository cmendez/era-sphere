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

        public string espacio_rentable_nombre { get; set; }

        public decimal precio_unitario { get; set; }

        [DisplayName("Detalle")]
        public string detalle { get; set; }
       
        [DisplayName("Unidades")]
        public int unidades { get; set; }
        public bool pagado { get; set; }
        
        [DisplayName("Puntos")]//los puntos se asignan una vez que ocurrio el pago
        public int puntos { get; set; }
        
        [DisplayName("Fecha de la transaccion")]
        public DateTime fecha { get; set; }//la fecha en la que se efectuo el pago 

        public bool de_servicio { get; set; }
        public bool de_reserva { get; set; }
        public bool de_evento { get; set; }
        public int origenID { get; set; }
        [DisplayName("Precio final")]
        public decimal precio_final { get { return precio_unitario * unidades; } }

        public ReciboLinea(string detalle, decimal precio_unitario, int Tipo, DateTime fecha, int unidades=1)
        {
            this.detalle = detalle;
            this.precio_unitario = precio_unitario;
            this.unidades = unidades;
            this.pagado = false;
            this.fecha = fecha;

            this.de_servicio = this.de_reserva = this.de_evento = false;
            if (Tipo == 0) {this.de_servicio = true;}
            if (Tipo == 1) {this.de_reserva = true;}
            if (Tipo == 2) {this.de_evento = true ;}

        }

        public ReciboLinea() { }
    }
}