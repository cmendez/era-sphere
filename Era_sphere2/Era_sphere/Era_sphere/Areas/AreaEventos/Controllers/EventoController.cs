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
using Era_sphere.Areas.AreaConfiguracion.Models.Servicios;
using Era_sphere.Areas.AreaHoteles.Models.HotelXServicioXTemporadaNM;
using Era_sphere.Areas.AreaContable.Models.Recibo;

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
        public ActionResult Select(int id_hotel, int estado)
        {
            return View("EventoIndex", new GridModel(evento_logica.retornarEventos(id_hotel).Where(e => e.estadoID == estado)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert(int id_hotel, int estado)
        {

            EventoView evento_view = new EventoView();

            if (TryUpdateModel(evento_view))
            {
                evento_view.estadoID = 1;
                evento_view.Hotel = id_hotel;
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

        public ActionResult DetalleEventoNoEdit(int id, int idhotel)
        {
            ViewBag.idhotel = idhotel;
            //ViewBag.idhotel = 1;
            ViewBag.idevento = id;
            return View("EventoLlenarDatosNoEdit");
        }

        #endregion

        //Adicional
        #region Adicional
        [GridAction]
        public ActionResult VerAdicionales(int id, int idEvento)
        {

            LogicaAdicional logicaAdicional = new LogicaAdicional();
            return PartialView("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteAdicional(int? id, int idEvento)
        {
            int adicional_id = id ?? -1;
            LogicaAdicional logicaAdicional = new LogicaAdicional();

            logicaAdicional.eliminarAdicional(adicional_id);
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));//falta ya noc reo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateAdicional(AdicionalView adicionalView, int id, int idEvento)
        {
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            adicionalView.eventoID = idEvento;
            logicaAdicional.modificarAdicional(adicionalView);
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));//falta ya no creo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertAdicional(int id, int idEvento)
        {
            //int idevento = id;
            AdicionalView adicional_view = new AdicionalView();
            LogicaAdicional logicaAdicional = new LogicaAdicional();
            if (TryUpdateModel(adicional_view))
            {
                adicional_view.eventoID = idEvento;
                logicaAdicional.agregarAdicional(adicional_view);

            }
            return View("EventoAdicionalView", new GridModel(logicaAdicional.retornarAdicionalesView(idEvento)));

        }
        #endregion

        //Participante
        #region participante
        [GridAction]
        public ActionResult VerParticipantes(int id, int idEvento)
        {
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            return PartialView("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteParticipante(int? id, int idEvento)
        {
            int participante_id = id ?? -1;
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            logicaParticipante.eliminarParticipante(participante_id);
            //int idevento = (logicaParticipante.retornarParticipante(participante_id)).eventoID;
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateParticipante(ParticipanteView participanteView, int id, int idEvento)
        {
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            //int idevento = participanteView.eventoID;
            participanteView.eventoID = idEvento;
            logicaParticipante.modificarParticipante(participanteView);
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertParticipante(int id, int idEvento)
        {
            //int idevento = id;
            ParticipanteView participante_view = new ParticipanteView();
            LogicaParticipante logicaParticipante = new LogicaParticipante();
            try
            {
                if (TryUpdateModel(participante_view))
                {
                    participante_view.eventoID = idEvento;
                    logicaParticipante.agregarParticipante(participante_view);

                }
            }
            catch (Exception e) { } 
            return View("EventoParticipanteView", new GridModel(logicaParticipante.retornarParticipantesView(idEvento)));

        }
        #endregion

        //EventoXAmbiente
        #region EventoXAmbiente
        public ActionResult AmbientesRestantes(int idHotel, int idEvento)
        {

            Thread.Sleep(500);
            //LogicaEventoXAmbiente logica_exa = new LogicaEventoXAmbiente();

            return Json(new SelectList(evento_logica.ambientesRestantes(idHotel, idEvento), "ID", "nombre"));
        }

        [GridAction]
        public ActionResult VerAmbientes(int id, int idEvento)
        {

            return PartialView("EventoAmbienteView", new GridModel(exa_logica.retornarAmbientes(idEvento)));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteAmbiente(int idEvento, EventoXAmbienteView ambiente)
        {
            evento_logica.eliminarAmbiente(idEvento, ambiente);
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
        public ActionResult InsertAmbiente(EventoXAmbienteView ambiente, int idEvento, DateTime fecha_hora_inicio, DateTime fecha_hora_fin)
        {
            //int idevento = id;
            int idambiente = ambiente.ambienteID;
            ambiente.eventoID = idEvento;
            ambiente.fecha_hora_inicio = fecha_hora_inicio;
            ambiente.fecha_hora_fin = fecha_hora_fin;
            evento_logica.agregarAmbienteAEvento(idEvento, ambiente, idambiente);

            return View("EventoEventoView", new GridModel(exa_logica.retornarAmbientes(idEvento)));

        }

        public ActionResult CargarAmbientes(int idEvento, DateTime fecha_hora_inicio, DateTime fecha_hora_fin, int idHotel)
        {

            ViewBag.idEvento = idEvento;
            ViewBag.fecha_inicio = fecha_hora_inicio;
            LogicaEventoXAmbiente lexa = new LogicaEventoXAmbiente();
            return PartialView("CargarAmbiente", lexa.retonarAmbienteHotel(idHotel, idEvento, fecha_hora_inicio, fecha_hora_fin));
        }
        #endregion


        public ActionResult CalcularCostos(int idEvento)
        {
            decimal costo = 0;
            Evento e = (new LogicaEvento()).retornarObjEvento(idEvento);


            LogicaServicios logicaServicio = new LogicaServicios();
            costo += logicaServicio.RetonarCostos(idEvento);

            LogicaEventoXAmbiente logicaExA = new LogicaEventoXAmbiente();
            costo += logicaExA.RetornarCosto(idEvento);

            ViewBag.precio = costo;
            int num_participantes = e.participantes.Count;
            evento_logica.modificarEvento(idEvento, costo, num_participantes);

            ViewBag.participantes = num_participantes;

            ViewBag.capacidad = logicaExA.retonarCapacidad(idEvento);

            ViewBag.is_full = ViewBag.capacidad <= ViewBag.participantes;

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
            if (clienteID == 1)
            {
                return Json(new SelectList((new LogicaCliente()).retonarClientesNaturales(), "ID", "nombre"), JsonRequestBehavior.AllowGet);
            }
            return Json(new SelectList((new LogicaCliente()).retonarClientesJuridicos(), "ID", "nombre"), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region servicios
        [GridAction]
        public ActionResult VerServicio(int idEvento)
        {
            LogicaServicios logicaServicio = new LogicaServicios();
            return PartialView("EventoServicioView", new GridModel(logicaServicio.retornarServicioView(idEvento)));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteServicio(int? id, int idEvento)
        {
            int servicio_id = id ?? -1;
            LogicaServicios logicaServicio = new LogicaServicios();

            logicaServicio.eliminarServicio(servicio_id);
            return View("EventoServicioView", new GridModel(logicaServicio.retornarServicioView(idEvento)));//falta ya noc reo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateServicio(ServicioView servicioView, int id, int idEvento)
        {
            LogicaServicios logicaServicio = new LogicaServicios();
            servicioView.eventoID = idEvento;
            if ((double)servicioView.precio_fijado > 0.0) servicioView.es_precio_fijado = true;
            logicaServicio.modificarServicio(servicioView);
            return View("EventoAdicionalView", new GridModel(logicaServicio.retornarServicioView(idEvento)));//falta ya no creo
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertServicio(int id, int idEvento)
        {
            //int idevento = id;
            Evento evento = (new LogicaEvento()).retornarObjEvento(idEvento);
            ServicioView servicio_view = new ServicioView();
            LogicaServicios logicaServicio = new LogicaServicios();
            if (TryUpdateModel(servicio_view))
            {
                if ((double)servicio_view.precio_fijado > 0.0) servicio_view.es_precio_fijado = true;
                servicio_view.precio_normal = (new LogicaHotelXTipoServicioXTemporada()).getPrecioTipoServicio(servicio_view.ID, evento.hotel, evento.fecha_inicio);
                servicio_view.eventoID = idEvento;
                logicaServicio.agregarServicio(servicio_view);

            }
            return View("EventoAdicionalView", new GridModel(logicaServicio.retornarServicioView(idEvento)));

        }

        public ActionResult ServicioPrecio(int idEvento, int idHotel, int tipo_servicio)
        {
            DateTime fecha = (new LogicaEvento()).retornarObjEvento(idEvento).fecha_inicio;
            decimal precio = (new LogicaHotelXTipoServicioXTemporada()).getPrecioTipoServicio(tipo_servicio, idHotel, fecha);
            ViewBag.precio = precio;
            //ViewBag.repeticiones = (new LogicaServicios()).retornarServicio(tipo_servicio).repeticiones;
            return PartialView("PrecioServicio");
        }

        #endregion

        #region pagos
        public JsonResult Nada(int id)
        {
            return Json(new { idEvento = id });
        }

        public ActionResult PagarEvento(int idEvento)
        {
            ViewBag.reciboLinea = (new EraSphereContext()).eventos.Find(idEvento).getReciboLineas().ToList();
            return PartialView("PagarEvento", (new LogicaEvento()).retornarEvento(idEvento));
        }

        public ActionResult MontosEvento(int idEvento)
        {
            EventoView evento = (new LogicaEvento()).retornarEvento(idEvento);
            ViewBag.precio_total = evento.precio_total;
            ViewBag.deuda = evento.precio_total - evento.pagado;
            ViewBag.pagado = evento.pagado;
            return PartialView("MontosEventos");
        }

        [GridAction]
        public ActionResult VerReciboLinea(int idEvento)
        {
            Evento evento = (new EraSphereContext()).eventos.Find(idEvento);
            List<ReciboLinea> lineas = evento.getReciboLineas();
            return PartialView("EventoReciboLinea", new GridModel(lineas));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult UpdateReciboLinea(ReciboLinea reciboLinea, int id, int idEvento)
        {
            Evento evento = (new EraSphereContext()).eventos.Find(idEvento);
            ReciboLinea linea = (new EraSphereContext()).recibos_lineas.Find(id);
            evento.pagado = evento.pagado - linea.precio_final + reciboLinea.precio_final;
            evento_logica.modificarEvento(new EventoView(evento));
            evento.modificarReciboLinea(reciboLinea, id);
            return View("EventoReciboLinea", new GridModel(evento.getReciboLineas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteReciboLinea(int id, int idEvento)
        {
            Evento evento = (new EraSphereContext()).eventos.Find(idEvento);
            ReciboLinea linea = (new EraSphereContext()).recibos_lineas.Find(id);
            evento.pagado = evento.pagado - linea.precio_final;
            evento_logica.modificarEvento(new EventoView(evento));
            evento.eliminarReciboLinea(id);
            return View("EventoReciboLinea", new GridModel(evento.getReciboLineas()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult InsertReciboLinea(int idEvento)
        {

            ReciboLinea linea = new ReciboLinea();
            Evento evento = (new EraSphereContext()).eventos.Find(idEvento);
            evento.estado_eventoID = 3;//Parcialmente pagado

            if (TryUpdateModel(linea))
            {
                linea.fecha = DateTime.Now;
                linea.de_evento = true;
                linea.detalle = "Pago de evento";
                evento.registraReciboLinea(linea);
            }
            evento.pagado = evento.pagado + linea.precio_final;
            evento_logica.modificarEvento(new EventoView(evento));

            return View("EventoReciboLinea", new GridModel(evento.getReciboLineas()));
        }
        #endregion
    }
}
        
    
