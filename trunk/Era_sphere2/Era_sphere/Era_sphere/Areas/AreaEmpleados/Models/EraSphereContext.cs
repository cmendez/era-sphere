using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaEmpleados.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Empleado> empleados { get; set; }

        void seedEmpleados() {
            empleados.Add(
                new Empleado { 
                    ID = 1,
                    tipo = tipos_personas.First(),
                    documento_identidad = "121212",
                    pais = paises.Find(1),
                    ciudad = paises.Find(1).ciudades.First(),
                    correo_electronico =  "121212@1212.c",
                    direccion = "1212121",
                    usuario = "admin",
                    password = "admin",
                    perfilID = 39
                }
                );
        }
    }
}
