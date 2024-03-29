﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;
using System.ComponentModel.DataAnnotations;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class PisoController : Controller
    {
        
        // GET: /AreaHoteles/Piso/
        InterfazLogicaPiso logica_piso = new LogicaPiso();
        // 
        PisoView piso = new PisoView();
        public ActionResult Index( int id )
        {
            /*List<PisoView> pisos = logica_piso.retornarPisos();
            if (pisos.Count() == 0)
                ViewData["nombre_hotel"] = "-";
            else
                ViewData["nombre_hotel"] = pisos[0].nombre_hotel;
            */

            ViewData["hotel"] = logica_piso.retornaNombreHotel(id);
            //TODO: eliminar la linea de arribita
            ViewData["hotelID"] = id;
           // List<PisoView> pisos = logica_piso.retornarPisos().Where(p => p.id_hotel == id).ToList();
            return View("IndexPiso");
        }

        

        [GridAction]
        public ActionResult Select( int id )
        {
            return View("Index", new GridModel(logica_piso.retornarPisosDeHotel(id)));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Insert( int id )
        {
            PisoView piso_view = new PisoView();
            if (TryUpdateModel(piso_view))
            {
                piso_view.id_hotel = id;
                logica_piso.agregarPiso(piso_view);
            }
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id)));
            //return View("Index", proveedor_logica.retornarProveedores(  ));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
        public ActionResult Delete(int? id, int id_hotel)
        {
            int piso_id = id ?? -1;
            logica_piso.eliminarPiso(piso_id);
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id_hotel)));
    
        }
        [AcceptVerbs(HttpVerbs.Post)]

        //[GridAction]
        //public ActionResult Update(PisoView piso, int id_hotel)
        //{

        //    logica_piso.modificarPiso(piso);
        //    return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id_hotel)));
     
        //}

        public ActionResult getHotel(int id)
        {
            var hotel = (new LogicaHotel()).retornarHotel(id);
            return Json(new { hotel = hotel });
        }

        public ActionResult registrarPisosBatch(int idHotel,int nroPisos)
        {
            logica_piso.registrarPisosBatch(idHotel,nroPisos);
            return Json(new { msg = "Hola Andre!"  });
        }

        [GridAction]
        public ActionResult Update(int id_hotel, IEnumerable<PisoView> inserted, IEnumerable<PisoView> updated, IEnumerable<PisoView> deleted)
        {
            if (inserted != null)
            {
                foreach (var piso_view in inserted)
                {
                    if (TryUpdateModel(piso_view))
                    {
                        piso_view.id_hotel = id_hotel;
                        logica_piso.agregarPiso(piso_view);
                    }
                }
            }

            if (updated != null)
            {
                foreach (var piso_view in updated)
                {
                    logica_piso.modificarPiso(piso_view); 
                }
            }

            if (deleted != null)
            {
                foreach (var piso_view in deleted)
                {
                    logica_piso.eliminarPiso(piso_view.ID);
                    logica_piso.eliminarHabsPiso(piso_view.ID);
                }
            }
            return View("IndexPiso", new GridModel(logica_piso.retornarPisosDeHotel(id_hotel)));
        }
    }
}
