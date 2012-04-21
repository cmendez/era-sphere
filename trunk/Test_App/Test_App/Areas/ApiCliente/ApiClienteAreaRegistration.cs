using System.Web.Mvc;

namespace Test_App.Areas.ApiCliente
{
    public class ApiClienteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiCliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Lista Clientes",
                "ApiCliente/Cliente",
                new { controller = "Cliente" , action = "ClientesLista"}
            );
            context.MapRoute(
                "ApiCliente_default",
                "ApiCliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Test Function",
                "ApiCliente/Cliente/Test",
                new { controller = "Cliente", action = "Test" }
            );
        }
    }
}
