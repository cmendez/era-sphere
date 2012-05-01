using System.Web.Mvc;

namespace Era_sphere.Areas.ApiConfiguracion
{
    public class ApiConfiguracionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiConfiguracion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ApiConfiguracion_default",
                "ApiConfiguracion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
