using System.Web.Mvc;

namespace Era_sphere.Areas.AreaEmpleados
{
    public class AreaEmpleadosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaEmpleados";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaEmpleados_default",
                "AreaEmpleados/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
