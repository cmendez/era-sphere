using System.Web.Mvc;

namespace Era_sphere.Areas.AreaCargos
{
    public class AreaCargosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaCargos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaCargos_default",
                "AreaCargos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
