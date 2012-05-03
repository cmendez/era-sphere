using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.Configuracion.Models;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaCliente.Models
{
    
        public class Cliente : Persona
        {

            public Cliente() 
            {
                //estado = EstadoCliente.sin_reserva;
                //tipo = TipoCliente.natural;
            }
            public enum EstadoCliente
            {
                con_reserva,
                sin_reserva,
                en_estadia
            };
            
           
            public string tarjeta_cliente { get; set; }
            public EstadoCliente estado { get; set; }  
        }

}