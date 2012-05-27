using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<EstadoCliente> estados_cliente { get; set; }

        public void seedEstadoCliente()
        {
            EstadoCliente estado_cliente_1 = new EstadoCliente{ descripcion = "Sin Reserva" };
            EstadoCliente estado_cliente_2 = new EstadoCliente { descripcion = "Con Reserva" };
            EstadoCliente estado_cliente_3 = new EstadoCliente { descripcion = "En Estadía" };
            estados_cliente.Add(estado_cliente_1);
            estados_cliente.Add(estado_cliente_2);
            estados_cliente.Add(estado_cliente_3);
            SaveChanges();

        }
    }
}
