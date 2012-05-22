using System.Web.Mvc;

namespace Era_sphere.Areas.AreaEmpleado
{
    public class AreaEmpleadoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaEmpleado";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaEmpleado_default",
                "AreaEmpleado/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
