using System.Web.Mvc;

namespace Era_sphere.Areas.AreaServicios
{
    public class AreaServiciosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaServicios";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaServicios_default",
                "AreaServicios/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
