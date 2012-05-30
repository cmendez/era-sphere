using System.Web.Mvc;

namespace Era_sphere.Areas.AreaPromociones
{
    public class AreaPromocionesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreaPromociones";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreaPromociones_default",
                "AreaPromociones/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
