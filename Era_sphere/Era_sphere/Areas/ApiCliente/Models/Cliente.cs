using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Era_sphere.Models
{
    public class Cliente
    {
        public class Cliente : Persona
        {
            enum Estados
            {
                con_reserva,
                sin_reserva,
                en_estadia
            };

            int cliente_id { get; set; }
            string tarjeta_cliente { get; set; }
            Estados estado { get; set; }
        }


    }

    public class ClienteEntities : DbContext
    {

        public DbSet<Cliente> clientes { get; set; }
    }

}