using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<LineaProducto> lineasproducto { get; set; }

        public void seedLineasProductos()
        {
            List<LineaProducto> lps = new List<LineaProducto>
            {
                new LineaProducto { descripcion = "Gaseosas" }, //1
                new LineaProducto { descripcion = "Vinos" },    //2
                new LineaProducto { descripcion = "Verduras" }, //3
                new LineaProducto { descripcion = "Frutas" },   //4
                new LineaProducto { descripcion = "Carnes" },   //5
                new LineaProducto { descripcion = "Pescados" }, //6
                new LineaProducto { descripcion = "Cervezas" }, //7
            };
            foreach(LineaProducto lp in lps) lineasproducto.Add(lp);
            SaveChanges();
        }
    }
}
