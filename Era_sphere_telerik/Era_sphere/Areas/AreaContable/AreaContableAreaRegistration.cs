using System.Web.Mvc;

namespace Era_sphere.Areas.AreaContable
{
    public class AreaContableAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaContable";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaContable_default",
                "AreaContable/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
