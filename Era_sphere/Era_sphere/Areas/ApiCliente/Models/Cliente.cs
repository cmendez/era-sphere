using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Drawing;

namespace Era_sphere.Models
{
    
        public class Cliente
        {
            enum Estados
            {
                con_reserva,
                sin_reserva,
                en_estadia
            };

            public int clienteID { get; set; }
            public string tarjeta_cliente { get; set; }
            Estados estado { get; set; }
            public string nombre { get; set; }
            public string apellido_paterno { get; set; }
            public string apellido_materno { get; set; }
            public string dni { get; set; }
            string pasaporte { get; set; }
            string correo_electronico { get; set; }
            string direccion { get; set; }
            string ruc { get; set; }
            string telefono { get; set; }
            string celular { get; set; }
            string razon_social { get; set; }
            Image foto_cliente { get; set; }
            //supuestamente deben de ir los atributos ciudad, país y provincia. 
            DateTime fecha_nacimiento { get; set; }
        }


    public class ClienteEntities : DbContext
    {

        public DbSet<Cliente> clientes { get; set; }
    }

}