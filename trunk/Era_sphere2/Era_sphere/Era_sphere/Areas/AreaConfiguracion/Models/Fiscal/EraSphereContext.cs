using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Perfiles;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using Era_sphere.Areas.AreaClientes.Models;
using Era_sphere.Areas.AreaReservas.Models;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Moneda> monedas { get; set; }
        public DbSet<TipoDePago> tiposdepagos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Orden> ordenes { get; set; }
        public DbSet<OrdenLinea> ordeneslineas { get; set; }
        public DbSet<proveedor_x_producto> p_x_p { get; set; }
        void crear_fiscal(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<proveedor_x_producto>().HasRequired(e => e.proveedor)
                                                    .WithMany(t => t.productos)
                                                    .HasForeignKey(e => e.proveedorID)
                                                    .WillCascadeOnDelete(false);
            
           
        }
        void seedProveedores() {
            Proveedor p = new Proveedor
            {
                ID = 1,
                razon_social = "Proveedor 1",
                ruc = "21234567890",
                telefono = "12312312",
                correo = "a@b.c",
                direccion = "direccion 1 ",
                persona_contacto = "Persona 1"
            };
         
            proveedores.Add(
                new Proveedor { 
                    ID = 2,
                    razon_social = "Proveedor 2",
                    ruc = "123123123",
                    telefono = "1212112",
                    correo = "ff@g.g",
                    direccion = "direccion 2",
                    persona_contacto = "Persona 2"
                }
          );
            p.productos = new List<proveedor_x_producto>();
            foreach (var x in productos) {
                proveedor_x_producto pp = new proveedor_x_producto
                {
                    ID = x.ID,
                    precio_unitario = x.ID + 0.5,
                    proveedor = p,
                    producto = x
                };
                p_x_p.Add(pp);
                p.productos.Add(pp);
            }
            
            proveedores.Add(p);

            foreach (var prov in proveedores)
            {
                prov.hoteles = new List<Hotel>();
                prov.hoteles.Add(hoteles.First());
            }

        }

        void seedProductos() {
            List<Producto> ps = new List<Producto>
            {
                //new LineaProducto { descripcion = "Gaseosas" }, //1
                new Producto { lineaProductoID = 1,  descripcion = "Inka Cola 1/2L",            isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 1,  descripcion = "Coca Cola Zero 1/2L",       isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                //new LineaProducto { descripcion = "Vinos" },    //2                
                new Producto { lineaProductoID = 2,  descripcion = "Vino Blanco Tacama",        isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 2,  descripcion = "Vino Rose Tacama",          isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 2,  descripcion = "Vino Blanco Concha y Toro", isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 2,  descripcion = "Vino Blanco Queirolo",      isPerecible = false,    diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                //new LineaProducto { descripcion = "Verduras" }, //3             
                new Producto { lineaProductoID = 3,  descripcion = "Brocoli",                   isPerecible = true,     diasPerecible = 10, unidadMedidad = "KG." },
                new Producto { lineaProductoID = 3,  descripcion = "Apio",                      isPerecible = true,     diasPerecible = 9,  unidadMedidad = "UNI." },
                new Producto { lineaProductoID = 3,  descripcion = "Zanahora",                  isPerecible = true,     diasPerecible = 10, unidadMedidad = "KG." },
                new Producto { lineaProductoID = 3,  descripcion = "Choclo",                    isPerecible = true,     diasPerecible = 8,  unidadMedidad = "UNI." },
                new Producto { lineaProductoID = 3,  descripcion = "Beterraga",                 isPerecible = true,     diasPerecible = 7,  unidadMedidad = "KG." },
                //new LineaProducto { descripcion = "Frutas" },   //4                 
                new Producto { lineaProductoID = 4,  descripcion = "Papaya",                    isPerecible = true,     diasPerecible = 5,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 4,  descripcion = "Piña",                    isPerecible = true,     diasPerecible = 6,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 4,  descripcion = "Manzana",                    isPerecible = true,     diasPerecible = 7,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 4,  descripcion = "Durazno",                    isPerecible = true,     diasPerecible = 5,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 4,  descripcion = "Granadilla",                    isPerecible = true,     diasPerecible = 6,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 4,  descripcion = "Lúcuma",                    isPerecible = true,     diasPerecible = 8,  unidadMedidad = "KG." },   
                //new LineaProducto { descripcion = "Carnes" },   //5
                new Producto { lineaProductoID = 5,  descripcion = "Lomo",                    isPerecible = true,     diasPerecible = 10,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 5,  descripcion = "Bisteck",                    isPerecible = true,     diasPerecible = 9,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 5,  descripcion = "Ozobuco",                    isPerecible = true,     diasPerecible = 8,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 5,  descripcion = "Asado de tira",                    isPerecible = true,     diasPerecible = 10,  unidadMedidad = "KG." },
                //new LineaProducto { descripcion = "Pescados" }, //6
                new Producto { lineaProductoID = 6,  descripcion = "Cojinova",                    isPerecible = true,     diasPerecible = 4,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 6,  descripcion = "Congrio",                    isPerecible = true,     diasPerecible = 4,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 6,  descripcion = "Lenguado",                    isPerecible = true,     diasPerecible = 4,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 6,  descripcion = "Ojo de uva",                    isPerecible = true,     diasPerecible = 4,  unidadMedidad = "KG." },
                new Producto { lineaProductoID = 6,  descripcion = "Trucha",                    isPerecible = true,     diasPerecible = 4,  unidadMedidad = "KG." },
                //new LineaProducto { descripcion = "Cervezas" }, //7                 
                new Producto { lineaProductoID = 7,  descripcion = "Pilsen Callao",                    isPerecible = false,     diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 7,  descripcion = "Barena",                    isPerecible = false,     diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 7,  descripcion = "Cusqueña",                    isPerecible = false,     diasPerecible = 0,  unidadMedidad = "BOTELLAS" },
                new Producto { lineaProductoID = 7,  descripcion = "Cusqueña Lata SixPack",                    isPerecible = false,     diasPerecible = 0,  unidadMedidad = "CAJAX6" }

            };

            foreach (Producto p in ps) productos.Add(p);
            SaveChanges();

            //for (int i = 0; i < 10; i++) {
            //    productos.Add(new Producto { ID = ( i + 1 ) , descripcion = "Producto " + ( i + 1 ) } );
            //}

        }

        void seedProvXProd()
        {
            //List<proveedor_x_producto> pxps = new List<proveedor_x_producto>
            //{
            //    new proveedor_x_producto { proveedorID = 1 , productoID = 1 , precio_unitario = 2.80 },
            //    new proveedor_x_producto { proveedorID = 1 , productoID = 3 , precio_unitario = 14.82 },
            //    new proveedor_x_producto { proveedorID = 1 , productoID = 4 , precio_unitario = 0.53 }
            //};
            //foreach(proveedor_x_producto pxp in pxps) p_x_p.Add(pxp);
            //SaveChanges();

        }

        void seedMonedas()
        {
            List<Moneda> mns = new List<Moneda>
            {
                new Moneda { descripcion = "Dólares Americanos", simbolo = "USD$", tc = 1.00M , paisID = 2 },
                new Moneda { descripcion = "Nuevos Soles", simbolo = "S/.", tc = 2.60M , paisID = 12 },
                new Moneda { descripcion = "Pesos chilenos", simbolo = "CLP$", tc = 500.7860M , paisID = 7 }
            };
            foreach (Moneda m in mns) this.monedas.Add(m);
            SaveChanges();
        }
    }
}
