using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Era_sphere.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginResult(String user, String password)
        {
            if (user == "admin" && password == "admin")
            {
                return Json(new { token = "1111111" });
            }
            else if (user == "xurreta" && password == "xurreta")
            {
                return Json(new { token = "1011111" });
            }
            else
            {
                return Json(new { token = "" });
            }

        }

        public ActionResult WebCliente() {
            return View("Cliente");
        }


        public ActionResult Sistema()
        {
            return View("Main");
        }
  

        /*
        public ActionResult Login(string usuario, string password) {
            if (usuario == "admin" && password == "admin") return View("Main");
            return View("Index");
        }
         * */
    }
}
