using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

namespace Era_sphere.Areas.AreaContable.Controllers
{
    public class OrdenesLineaController : Controller
    {
        //
        // GET: /AreaContable/OrdenesLinea/

        public ActionResult Index(int? oid)
        {
            return View("IndexOrdenesLinea");
        }

        [GridAction]
        public ActionResult Select()
        {
            List<Orden> os = db.ordenes.ToList();
            List<OrdenView> ovs = new List<OrdenView>();
            foreach (Orden o in os) ovs.Add(new OrdenView(o));
            return View("IndexOrdenes", new GridModel(ovs));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Insert()
        {

            OrdenView ov = new OrdenView();
            if (TryUpdateModel(ov))
            {
                Orden o = ov.deserealizar();
                db.ordenes.Add(o);
                db.SaveChanges();
            }
            return View("IndexOrdenes", new GridModel(db.ordenes.ToList()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            db.ordenes.Remove(db.ordenes.Find(id));
            db.SaveChanges();
            return View("Index", new GridModel(db.ordenes.ToList()));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(OrdenView ov)
        {
            Orden o = ov.deserealizar();
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return View("Index", new GridModel(db.ordenes.ToList()));
        }

    }
}
