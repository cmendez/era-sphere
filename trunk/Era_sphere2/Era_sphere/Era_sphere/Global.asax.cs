using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Era_sphere.Areas.AreaClientes.Models;
using System.Data.Entity;
using Era_sphere.Areas.Configuracion.Models;
using Era_sphere.Models;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;

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
            //.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Era_sphere.PaisDBContext__Era_sphere.Areas.Configuracion.Models_>());
            //Database.SetInitializer<PaisDBContext>(new PaisInitializer());
            Database.SetInitializer<CiudadDBContext>(new DropCreateDatabaseAlways<CiudadDBContext>());
            Database.SetInitializer<ProvinciaDBContext>(new DropCreateDatabaseAlways<ProvinciaDBContext>());

            AreaRegistration.RegisterAllAreas();
            //Database.SetInitializer<ClienteContext>(new DropCreateDatabaseIfModelChanges<ClienteContext>());
            //Database.SetInitializer<UbigeoContext>(new DropCreateDatabaseAlways<UbigeoContext>());
            //Database.SetInitializer<HotelContext>(new DropCreateDatabaseIfModelChanges<HotelContext>());
            //prueba para que funcione el mantenimiento de pisos T_T
            Database.SetInitializer<ComodidadesContext>(new DropCreateDatabaseAlways<ComodidadesContext>());
            Database.SetInitializer<HabitacionContext>(new DropCreateDatabaseAlways<HabitacionContext>());
            Database.SetInitializer<PisoContext>(new DropCreateDatabaseAlways<PisoContext>());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}