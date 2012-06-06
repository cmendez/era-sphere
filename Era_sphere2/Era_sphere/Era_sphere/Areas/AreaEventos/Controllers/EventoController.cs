using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaEventos.Models.Evento;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaEventos.Models.Adicionales;
using Era_sphere.Areas.AreaEventos.Models.Participante;
using Era_sphere.Areas.AreaEventos.Models.EventoXAmbiente;

namespace Era_sphere.Areas.AreaEventos.Controllers
{
    public class EventoController : Controller
    {
        //
        // GET: /AreaEventos/Evento/

        LogicaEvento evento_logica = new LogicaEvento();

        
        public ActionResult Index(int id)
        {
            LogicaHotel logicaHotel = new LogicaHotel();

            Hotel hotel = logicaHotel.retornarObjHotel(id);
            ViewData["id_hotel"] = id;
            ViewData["nombre_hotel"] = hotel.razon_social;
            return View("EventoIndex",evento_logica.retornarEventos(id));
        }

        [GridAction]
        public ActionResult Select(int id_hotel)
        {
            return View("EventoAdicionalView", new GridModel(evento_logica.retornarEventos(id_hotel)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int id_hotel)
        {

            EventoView evento_view= new EventoView();
            
            if (TryUpdateModel(evento_view))
            {
                //evento_view.idHotel =id_hotel;
                evento_logica.agregarEvento(evento_view);

            }
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel)));

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int evento_id = id ?? -1;
            evento_logica.eliminarEvento(evento_id);
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(EventoView p, int id_hotel)
        {
            evento_logica.modificarEvento(p);
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel)));
        }

        public ActionResult DetalleEvento(int id, int idhotel)
        {
            ViewBag.idhotel = idhotel;
            return View("EventoLlenarDatos");
        }

        //Adicional
        [GridAction]
        public ActionResult VerAdicionales(int id,int idhotel)
        {
            //ViewBag.idevento=id;
            LogicaAdicional logicaAdicional=new LogicaAdicional();
            return PartialView("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(id)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteAdicional(int? id)
        {
            int adicional_id = id ?? -1;
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            int idevento=(logicaAdicional.retornarAdicional(adicional_id)).eventoID;
            logicaAdicional.eliminarAdicional(adicional_id);
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idevento)));//falta ya noc reo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateAdicional(AdicionalView adicionalView, int id )
        {
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            //adicionalView.eventoID = id;
            int idevento=adicionalView.eventoID;//el adiciona llega sin eventoID pero el id entrante es el del evento
            logicaAdicional.modificarAdicional(adicionalView);
            return View("EventoAdicionalView",new GridModel(logicaAdicional.retornarAdicionalesView(idevento)));//falta ya no creo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertAdicional( int id)
        {
            int idevento = id;
            AdicionalView adicional_view= new AdicionalView();
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            if (TryUpdateModel(adicional_view))
            {
                adicional_view.eventoID =idevento;
                logicaAdicional.agregarAdicional(adicional_view);

            }
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idevento)));

        }

        //Participante
        [GridAction]
        public ActionResult VerParticipantes(int id, int idhotel)
        {
            LogicaParticipante logicaParticipante= new LogicaParticipante();
            return PartialView("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(id)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteParticipante(int? id, int idhotel)
        {
            int participante_id = id ?? -1;
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            logicaParticipante.eliminarParticipante(participante_id);
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(participante_id)));
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //[GridAction]
        //public ActionResult UpdateAdicional(AdicionalView adicionalView, int id, int idhotel)
        //{
        //    LogicaAdicional logicaAdicional = new LogicaAdicional();
        //    logicaAdicional.modificarAdicional(adicionalView);
        //    return View("EventoIndex", new GridModel(evento_logica.retornarEventos(idhotel)));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //[GridAction]
        //public ActionResult InsertParticipante(int id, int idhotel)
        //{

        //    AdicionalView adicional_view = new AdicionalView();
        //    LogicaAdicional logicaAdicional = new LogicaAdicional();
        //    if (TryUpdateModel(adicional_view))
        //    {
        //        adicional_view.eventoID = id;
        //        logicaAdicional.agregarAdicional(adicional_view);

        //    }
        //    return View("EventoParticipanteView", new GridModel(logicaAdicional.retornarAdicionalesView(idhotel)));

        //}
        
    }
}
