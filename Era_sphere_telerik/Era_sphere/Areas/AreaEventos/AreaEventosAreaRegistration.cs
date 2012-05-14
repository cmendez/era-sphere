using System.Web.Mvc;

namespace Era_sphere.Areas.AreaEventos
{
    public class AreaEventosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaEventos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaEventos_default",
                "AreaEventos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
