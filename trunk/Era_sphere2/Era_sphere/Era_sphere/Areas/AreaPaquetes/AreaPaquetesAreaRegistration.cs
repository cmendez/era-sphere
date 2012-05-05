using System.Web.Mvc;

namespace Era_sphere.Areas.AreaPaquetes
{
    public class AreaPaquetesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaPaquetes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaPaquetes_default",
                "AreaPaquetes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
