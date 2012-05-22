using System.Web.Mvc;

namespace Era_sphere.Areas.AreaReportes
{
    public class AreaReportesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaReportes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaReportes_default",
                "AreaReportes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
