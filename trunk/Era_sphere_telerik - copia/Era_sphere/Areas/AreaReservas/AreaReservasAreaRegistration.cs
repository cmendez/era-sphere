using System.Web.Mvc;

namespace Era_sphere.Areas.AreaReservas
{
    public class AreaReservasAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaReservas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaReservas_default",
                "AreaReservas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
