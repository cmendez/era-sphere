using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;
using Era_sphere.Areas.ApiConfiguracion.Models;

namespace Era_sphere.Areas.ApiCliente.Models
{
    
        public class Cliente
        {

            public Cliente() 
            {
                estado = EstadoCliente.sin_reserva;
                tipo = TipoCliente.juridico;
            }
            public enum EstadoCliente
            {
                con_reserva,
                sin_reserva,
                en_estadia
            };
            public enum TipoCliente
            {
                natural,
                juridico
            };
           
            public int clienteID { get; set; }
            public string tarjeta_cliente { get; set; }
            public EstadoCliente estado { get; set; }
            public string nombre { get; set; }
            public string apellido_paterno { get; set; }
            public string apellido_materno { get; set; }
            public string dni { get; set; }
            public string pasaporte { get; set; }
            public string correo_electronico { get; set; }
            public string direccion { get; set; }
            public string ruc { get; set; }
            public string telefono { get; set; }
            public string celular { get; set; }
            public string razon_social { get; set; }
            //public Image foto_cliente { get; set; }
            public Ciudad ciudad { get; set; }
            public Pais pais { get; set; }
            //supuestamente deben de ir los atributos ciudad, país y provincia. 
            public DateTime fecha_nacimiento { get; set; }
            public TipoCliente tipo { get; set; }  
        }

}