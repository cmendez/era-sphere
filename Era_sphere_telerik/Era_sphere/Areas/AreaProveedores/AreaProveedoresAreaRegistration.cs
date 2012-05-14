using System.Web.Mvc;

namespace Era_sphere.Areas.AreaProveedores
{
    public class AreaProveedoresAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaProveedores";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaProveedores_default",
                "AreaProveedores/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
