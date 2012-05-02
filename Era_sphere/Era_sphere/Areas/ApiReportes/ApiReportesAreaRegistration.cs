using System.Web.Mvc;

namespace Era_sphere.Areas.ApiReportes
{
    public class ApiReportesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiReportes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ApiReportes_default",
                "ApiReportes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
