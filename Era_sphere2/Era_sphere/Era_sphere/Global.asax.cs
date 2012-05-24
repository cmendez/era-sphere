using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Era_sphere.Areas.AreaClientes.Models;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models;
using Era_sphere.Models;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Era_sphere.PaisDBContext__Era_sphere.Areas.Configuracion.Models_>());
            //Database.SetInitializer<PaisDBContext>(new PaisInitializer());
            /*Database.SetInitializer<CiudadDBContext>(new DropCreateDatabaseIfModelChanges<CiudadDBContext>());
            Database.SetInitializer<ProvinciaDBContext>(new DropCreateDatabaseIfModelChanges<ProvinciaDBContext>());

            
            Database.SetInitializer<ClienteContext>(new DropCreateDatabaseIfModelChanges<ClienteContext>());
            Database.SetInitializer<UbigeoContext>(new DropCreateDatabaseIfModelChanges<UbigeoContext>());
            Database.SetInitializer<HotelContext>(new DropCreateDatabaseIfModelChanges<HotelContext>());
            //prueba para que funcione el mantenimiento de pisos T_T
            Database.SetInitializer<ComodidadesContext>(new DropCreateDatabaseIfModelChanges<ComodidadesContext>());
            Database.SetInitializer<AmbienteContext>(new DropCreateDatabaseIfModelChanges<AmbienteContext>());
            Database.SetInitializer<HabitacionContext>(new DropCreateDatabaseIfModelChanges<HabitacionContext>());
            Database.SetInitializer<PisoContext>(new DropCreateDatabaseIfModelChanges<PisoContext>());
            Database.SetInitializer(new MonedaContextInitializer());
            Database.SetInitializer(new TipoDePagoContextInitializer());*/
            Database.SetInitializer<EraSphereContext>(new EraSphereContextInitializer());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

        }
    }
}