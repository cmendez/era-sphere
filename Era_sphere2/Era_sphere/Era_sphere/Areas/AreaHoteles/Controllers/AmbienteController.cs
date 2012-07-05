using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaHoteles.Models.Habitaciones;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class AmbienteController : Controller
    {
        //
        // GET: /AreaHoteles/Ambiente/

        InterfazLogicaAmbiente logica_ambiente = new LogicaAmbiente();
        InterfazLogicaPiso logica_pisos = new LogicaPiso();

        public ActionResult Index(int id)
        {
            //(new EstadoEspacioRentableInitializer()).Seed(new EraSphereContext());
            ViewData["hotelID"] = id;
            ViewData["pisos"] = logica_pisos.retornarPisosDeHotel(id);
            return View("IndexAmbiente");
        }

        [GridAction]
        public ActionResult Select(int hotelID)
        {
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes(hotelID)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert(int hotelID)
        {
            AmbienteView ambiente_view = new AmbienteView();
            if (TryUpdateModel(ambiente_view))
            {
                logica_ambiente.agregarAmbiente(ambiente_view);
            }
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes(hotelID)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int hotelID)
        {
            int ambiente_id = id ?? -1;
            logica_ambiente.eliminarAmbiente(ambiente_id);
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes(hotelID)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Update(AmbienteView ambiente, int hotelID)
        {

            logica_ambiente.modificarAmbiente(ambiente);
            return View("Index", new GridModel(logica_ambiente.retornarAmbientes(hotelID)));
        }

        public ActionResult RetornarAmbiente(int ID)
        {
            
            return PartialView("AmbienteInformacion", (new LogicaAmbiente()).retornarAmbiente(ID));
        }
    }
}
