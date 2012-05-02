using System.Web.Mvc;

namespace Era_sphere.Areas.ApiEmpleados
{
    public class ApiEmpleadosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ApiEmpleados";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ApiEmpleados_default",
                "ApiEmpleados/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
