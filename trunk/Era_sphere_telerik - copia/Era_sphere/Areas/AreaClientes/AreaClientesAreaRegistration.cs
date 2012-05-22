using System.Web.Mvc;

namespace Era_sphere.Areas.AreaClientes
{
    public class AreaClientesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaClientes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaClientes_default",
                "AreaClientes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
