using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Objects;
using System.Data;

namespace Era_sphere.Generics
{
    
    public partial class EraSphereContext : DbContext
    {
        public EraSphereContext()// : base("Data Source=inti.lab.inf.pucp.edu.pe;Initial Catalog=inf2450881g4;Persist Security Info=True;User ID=inf2450881g4dba;Password=zapatilla")
        {
        }

        public void seed(){
            seedTipoDocumentoCliente();
            seedUbigeo();
            seedMonedas();
            seedHotel();
            seedOrdenCompra();
            seedEstadoEspacioRentable();
            seedEstadoCliente();
            seedTipoPersona();
            seedTipoDocumentoCliente();
            seedServicios();
            seedTipoTemporadas();
            seedTemporadas();
            seedEstadoReserva();
            seedLineasProductos();
            seedProductos();
            seedProveedores();
            seedRelacionesPromocion();
            seedOrdenCompra();
            seedTipoHabitaciones();
            seedComodidades();
            seedPisos();
            seedClientes();
            seedHabitaciones();
            seedPerfil();
            seedEmpleados();
            seedCadena();
            seedAmbientes();
        }

        public DbSet<TipoPersona> tipos_personas { get; set; }
        public void seedTipoPersona()
        {
            TipoPersona natural = new TipoPersona { ID = 1, descripcion = "Natural" };
            TipoPersona juridico = new TipoPersona { ID = 2, descripcion = "Juridico" };
            tipos_personas.Add(natural);
            tipos_personas.Add(juridico);
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            crear_fiscal(modelBuilder);
            crear_orden_compra(modelBuilder);
            //crear_eventos_servicios(modelBuilder);
        }

    }




    public class EraSphereContextInitializer : DropCreateDatabaseIfModelChanges<EraSphereContext>{
        protected override void Seed(EraSphereContext context){
            context.seed();
        }
    }
}
