using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaContable.Models.Pagos
{
    public class PagoTarjeta
    {
        [DisplayName("Tarjeta")]
        [Required]
        public string tipo_tarjeta { get; set; }
       
        [DisplayName("Numero de la tarjeta")]
        [StringLength(16)]
        [Required]
        public string num_tarjeta { get; set; }

        [DisplayName("Mes")]
        [Required]
        public int mes_vencimiento { get; set; }
        
        [DisplayName("Año")]
        [Required]
        public int ano_vencimiento { get; set; }

        [DisplayName("CVV2 o CVC2")]
        [Required]
        public int pin { get; set; }

        public decimal monto { get; set; }
    }
}