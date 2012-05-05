using System.Web.Mvc;

namespace Era_sphere.Areas.AreaHoteles
{
    public class AreaHotelesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaHoteles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaHoteles_default",
                "AreaHoteles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
