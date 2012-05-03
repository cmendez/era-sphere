using System.Web.Mvc;

namespace Era_sphere.Areas.Empleados
{
    public class EmpleadosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Empleados";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Empleados_default",
                "Empleados/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
