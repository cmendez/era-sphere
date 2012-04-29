using System.Web.Mvc;

namespace Era_sphere.Areas.ApiClientes
{
    public class ApiClientesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiClientes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ApiClientes_default",
                "ApiClientes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
