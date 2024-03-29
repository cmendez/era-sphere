﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Era_sphere.Areas.AreaClientes.Models;
using System.Data.Entity;
using Era_sphere.Areas.AreaProveedores.Models;

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
                "", // Route name
                "Areas/AreaProveedores/{controller}/{action}", // URL with parameters
                new { controller = "Proveedor", action = "Index" } // 
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 
            );

            /*
            

            
             routes.MapRoute(
                "Areas",// Route name 
                "AreaProveedores/{controller}/{action}/{id}", 
                new {
                    controller = "ProveedorController",
                    action = "Index" 
                }  
            );
             */

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer<ClienteContext>(new DropCreateDatabaseIfModelChanges<ClienteContext>());
            Database.SetInitializer<ProveedorContext>( new DropCreateDatabaseAlways<ProveedorContext>());
            (new ProveedorContext()).Seed();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}