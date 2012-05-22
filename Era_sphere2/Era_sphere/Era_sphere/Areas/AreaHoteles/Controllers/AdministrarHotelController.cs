using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaHoteles.Models;

namespace Era_sphere.Areas.AreaHoteles.Controllers
{
    public class AdministrarHotelController : Controller
    {
        //
        // GET: /AreaHoteles/AdministrarHotel/

        InterfazLogicaHotel logica_hotel = new LogicaHotel();

        public ActionResult Index()
        {
            return View( logica_hotel.retornarHoteles() );
        }

        public ActionResult Administrar(int id) {
            
            ViewData["id"] = id;
            ViewData["razon_hotel"] = logica_hotel.retornarHotel(id).razon_social;
            return View();
        }

        public ActionResult AgregarPisos(int id) {
            return View("Index");
        }
    }
}
