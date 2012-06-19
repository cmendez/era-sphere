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
using System.Threading;
using Era_sphere.Areas.AreaHoteles.Models.Ambientes;
using Era_sphere.Areas.AreaClientes.Models;

namespace Era_sphere.Areas.AreaEventos.Controllers
{
    public class EventoController : Controller
    {
        //
        // GET: /AreaEventos/Evento/

        LogicaEvento evento_logica = new LogicaEvento();
        LogicaEventoXAmbiente exa_logica = new LogicaEventoXAmbiente();

        #region evento
        public ActionResult Index(int id)
        {
            LogicaHotel logicaHotel = new LogicaHotel();

            Hotel hotel = logicaHotel.retornarObjHotel(id);
            ViewData["id_hotel"] = id;
            ViewData["nombre_hotel"] = hotel.razon_social;
            return View("EventoIndex");
        }

        [GridAction]
        public ActionResult Select(int id_hotel,int estado)
        {
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel).Where(e => e.estadoID == estado)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int id_hotel, int estado)
        {

            EventoView evento_view= new EventoView();
            
            if (TryUpdateModel(evento_view))
            {
                evento_view.estadoID = estado;
                evento_view.Hotel =id_hotel;
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
            p.Hotel = id_hotel;
            evento_logica.modificarEvento(p);
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel)));
        }

        public ActionResult DetalleEvento(int id, int idhotel)
        {
            ViewBag.idhotel = idhotel;
            //ViewBag.idhotel = 1;
            ViewBag.idevento = id;
            return View("EventoLlenarDatos");
        }
        #endregion 

        //Adicional
        #region Adicional
        [GridAction]
        public ActionResult VerAdicionales(int id,int idEvento)
        {
            
            LogicaAdicional logicaAdicional=new LogicaAdicional();
            return PartialView("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteAdicional(int? id,int idEvento)
        {
            int adicional_id = id ?? -1;
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            
            logicaAdicional.eliminarAdicional(adicional_id);
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));//falta ya noc reo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateAdicional(AdicionalView adicionalView, int id ,int idEvento)
        {
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            adicionalView.eventoID = idEvento;      
            logicaAdicional.modificarAdicional(adicionalView);
            return View("EventoAdicionalView",new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));//falta ya no creo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertAdicional( int id,int idEvento)
        {
            //int idevento = id;
            AdicionalView adicional_view= new AdicionalView();
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            if (TryUpdateModel(adicional_view))
            {
                adicional_view.eventoID =idEvento;
                logicaAdicional.agregarAdicional(adicional_view);

            }
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));

        }
        #endregion 

        //Participante
        #region participante
        [GridAction]
        public ActionResult VerParticipantes(int id,int idEvento)
        {
            LogicaParticipante logicaParticipante= new LogicaParticipante();
            return PartialView("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteParticipante(int? id,int idEvento)
        {
            int participante_id = id ?? -1;
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            logicaParticipante.eliminarParticipante(participante_id);
            //int idevento = (logicaParticipante.retornarParticipante(participante_id)).eventoID;
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateParticipante(ParticipanteView participanteView, int id,int idEvento)
        {
            LogicaParticipante logicaParticipante= new LogicaParticipante();
            //int idevento = participanteView.eventoID;
            participanteView.eventoID = idEvento;
            logicaParticipante.modificarParticipante(participanteView);
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertParticipante(int id,int idEvento)
        {
            //int idevento = id;
            ParticipanteView participante_view = new ParticipanteView();
            LogicaParticipante logicaParticipante= new LogicaParticipante();
            if (TryUpdateModel(participante_view))
            {
                participante_view.eventoID = idEvento;
                logicaParticipante.agregarParticipante(participante_view);

            }
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));

        }
        #endregion 

        //EventoXAmbiente
        #region EventoXAmbiente
        public ActionResult AmbientesRestantes(int idHotel,int idEvento)
        {
            
            Thread.Sleep(500);
            //LogicaEventoXAmbiente logica_exa = new LogicaEventoXAmbiente();

            return Json( new SelectList( evento_logica.ambientesRestantes( idHotel ,idEvento), "ID" , "nombre"));
        }

        [GridAction]
        public ActionResult VerAmbientes(int id, int idEvento)
        {
            
            return PartialView("EventoAmbienteView", new GridModel(exa_logica.retornarAmbientes(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteAmbiente( int idEvento,EventoXAmbienteView ambiente)
        {   
            evento_logica.eliminarAmbiente(idEvento,ambiente);
            return View("EventoEventoView", new GridModel(exa_logica.retornarAmbientes(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateAmbiente(EventoXAmbienteView ambiente, int id, int idEvento)
        {
            //LogicaParticipante logicaParticipante = new LogicaParticipante();
            //int idevento = participanteView.eventoID;
            evento_logica.modificarAmbiente(idEvento, ambiente);
            return View("EventoEventoView", new GridModel(exa_logica.retornarAmbientes(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertAmbiente(EventoXAmbienteView ambiente, int idEvento,DateTime fecha_hora_inicio,DateTime fecha_hora_fin)
        {
            //int idevento = id;
            int idambiente=ambiente.ambienteID;
            ambiente.eventoID = idEvento;
            ambiente.fecha_hora_inicio = fecha_hora_inicio;
            ambiente.fecha_hora_fin = fecha_hora_fin;
            evento_logica.agregarAmbienteAEvento(idEvento, ambiente,idambiente);

            return View("EventoEventoView", new GridModel(exa_logica.retornarAmbientes(idEvento)));

        }
        
        public ActionResult CargarAmbientes(int idEvento,DateTime fecha_hora_inicio,DateTime fecha_hora_fin,int idHotel){

            ViewBag.idEvento = idEvento;
            ViewBag.fecha_inicio = fecha_hora_inicio;
            LogicaEventoXAmbiente lexa=new LogicaEventoXAmbiente();
            return PartialView("CargarAmbiente", lexa.retonarAmbienteHotel(idHotel,idEvento,fecha_hora_inicio,fecha_hora_fin));
        }
        #endregion 

        
        public ActionResult CalcularCostos(int idEvento)
        {
            decimal costo = 0;

            LogicaAdicional logicaAdicional = new LogicaAdicional();
            costo += logicaAdicional.RetornarCosto(idEvento);

            LogicaEventoXAmbiente logicaExA= new LogicaEventoXAmbiente();
            costo += logicaExA.RetornarCosto(idEvento);

            ViewBag.precio = costo;
            evento_logica.modificarEvento(idEvento, costo);

            return View("EventoCalcularCostos");
        }

        public ActionResult Prueba(int id)
        {
            return View("PruebaHtml");
        }

        #region cliente
        public ActionResult BuscarCliente()
        {
            return PartialView("EventoCliente");
        }

        public JsonResult TraerClientes(int clienteID)
        {
            if (clienteID==1){
                return Json(new SelectList((new LogicaCliente()).retonarClientesNaturales(), "ID", "nombre"), JsonRequestBehavior.AllowGet);
            }
            return Json(new SelectList((new LogicaCliente()).retonarClientesJuridicos(), "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
