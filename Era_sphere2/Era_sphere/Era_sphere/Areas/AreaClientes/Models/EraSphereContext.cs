using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<EstadoCliente> estados_cliente { get; set; }

        public void seedEstadoCliente()
        {
            EstadoCliente estado_cliente_1 = new EstadoCliente{ ID = 1, descripcion = "Sin Reserva" };
            EstadoCliente estado_cliente_2 = new EstadoCliente { ID = 2, descripcion = "Con Reserva" };
            EstadoCliente estado_cliente_3 = new EstadoCliente { ID = 3, descripcion = "En Estadía" };
            estados_cliente.Add(estado_cliente_1);
            estados_cliente.Add(estado_cliente_2);
            estados_cliente.Add(estado_cliente_3);
            SaveChanges();

        }

        public void seedClientes()
        {
            Pais pais = paises.Find(1);
            Ciudad ciudad = ciudades.Find(1);
            EstadoCliente sin_reserva = estados_cliente.Find(1);
            TipoPersona natural = tipos_personas.Find(1);
            TipoPersona juridico = tipos_personas.Find(2);
            Cliente c1 = new Cliente
            {
                ID = 1,
                nombre = "xurrepom",
                pais = pais,
                paisID = pais.ID,
                ciudad = ciudad,
                ciudadID = ciudad.ID,
                tipo = natural,
                tipoID = natural.ID,
                tarjeta_cliente = "aaa",
                documento_identidad = "121321321",
                apellido_materno = "hoces",
                apellido_paterno = "lepage",
                estado = sin_reserva,
                estadoID = sin_reserva.ID,
            };
            Cliente c2 = new Cliente
            {
                ID = 2,
                nombre = "chotita",
                pais = pais,
                paisID = pais.ID,
                ciudad = ciudad,
                ciudadID = ciudad.ID,
                tipo = natural,
                tipoID = natural.ID,
                tarjeta_cliente = "asdfdsaf",
                documento_identidad = "11235813",
                apellido_materno = "quispesaravia",
                apellido_paterno = "tamagotchi",
                estado = sin_reserva,
                estadoID = sin_reserva.ID,
            };
            Cliente c3 = new Cliente
            {
                ID = 3,
                razon_social = "yeti S.A.",
                pais = pais,
                paisID = pais.ID,
                ciudad = ciudad,
                ciudadID = ciudad.ID,
                tipo = juridico,
                tipoID = juridico.ID,
                tarjeta_cliente = "zxcvzv",
                ruc = "1234345457",
                estado = sin_reserva,
                estadoID = sin_reserva.ID,
            };
            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            SaveChanges();
        }
    }
}
