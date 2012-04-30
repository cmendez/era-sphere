using System.Web.Mvc;

namespace Era_sphere.Areas.ApiCliente
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
                "ApiCliente_default",
                "ApiCliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
