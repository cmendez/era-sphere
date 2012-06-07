using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models.Ordenes;
using Era_sphere.Models;
using Era_sphere.Generics;

using Telerik.Web.Mvc;

using Era_sphere.Areas.AreaContable.Models;

namespace Era_sphere.Areas.AreaContable.Controllers
{ 
    public class OrdenesController : Controller
    {
        private EraSphereContext db = new EraSphereContext();
        private static int? productoID;
        private static int? proveedorID;

        //
        // GET: /AreaContable/Ordenes/
        public ActionResult Index()
        {
            return View("IndexOrdenes");
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

        public ActionResult agregar()
        {
            Orden o = new Orden
            {
                estado = 1,
                fechaRegistro = DateTime.Today,
                totalIGV = 0,
                total = 0,
                ordenlineas = new List<OrdenLinea>()
            };
            db.ordenes.Add(o);
            db.SaveChanges();

            ViewData["oid"] = o.ID;

            return View("AgregarOrden");
        }

        public ActionResult SelectLineas(int oid)
        {
            ICollection<OrdenLineaView> olvs = new List<OrdenLineaView>();
            ICollection<OrdenLinea> ols = db.ordenes.Find(oid).ordenlineas;
            foreach (OrdenLinea ol in ols) olvs.Add(new OrdenLineaView(ol));

            ViewData["oid"] = oid;
            return View("AgregarOrden", new GridModel(olvs));
        }

        public ActionResult InsertLinea(int oid)
        {
            OrdenLineaView olv = new OrdenLineaView();

            if (TryUpdateModel(olv))
            {
                OrdenLinea o = olv.deserealizar(oid);
                db.ordeneslineas.Add(o);
                db.SaveChanges();
            }

            ICollection<OrdenLineaView> olvs = new List<OrdenLineaView>();
            ICollection<OrdenLinea> ols = db.ordenes.Find(oid).ordenlineas;
            foreach (OrdenLinea ol in ols) olvs.Add(new OrdenLineaView(ol));

            ViewData["oid"] = oid;
            return View("AgregarOrden", new GridModel(olvs));
        }

        public JsonResult _GetDropDownListProveedores(int? productoID)
        {
            OrdenesController.productoID = productoID;
            ICollection<proveedor_x_producto> pxps = db.productos.Find(productoID).proveedores;
            List<Proveedor> pvs = new List<Proveedor>();
            foreach (proveedor_x_producto pxp in pxps) pvs.Add( pxp.proveedor );
            return Json(new SelectList(pvs, "ID", "razon_social"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult _GetDropDownListPrecio(int? proveedorID)
        {
            OrdenesController.proveedorID = proveedorID;
            double p = db.productos.Find(OrdenesController.productoID).proveedores.Single(pr => pr.proveedorID == proveedorID).precio_unitario;
            List<Decimal> pl = new List<Decimal>();
            pl.Add(new Decimal(p));
            return Json(new SelectList(pl), JsonRequestBehavior.AllowGet);
        }



    }
}




            //if (db.ordenes.ToList().Count == 0) ViewData["oid"] = 0;
            //else ViewData["oid"] = db.ordenes.OrderByDescending(o => o.ID).FirstOrDefault().ID + 1;





        //public ViewResult Index()
        //{
        //    var ordenes = db.ordenes.Include(o => o.empleado_solicita);
        //    return View(ordenes.ToList());
        //}

        ////
        //// GET: /AreaContable/Ordenes/Details/5

        //public ViewResult Details(int? id)
        //{
        //    Orden orden = db.ordenes.Find(id);
        //    return View(orden);
        //}

        ////
        //// GET: /AreaContable/Ordenes/Create

        //public ActionResult Create()
        //{
        //    ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion");
        //    return View();
        //} 

        ////
        //// POST: /AreaContable/Ordenes/Create

        //[HttpPost]
        //public ActionResult Create(Orden orden)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ordenes.Add(orden);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");  
        //    }

        //    ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
        //    return View(orden);
        //}
        
        ////
        //// GET: /AreaContable/Ordenes/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    Orden orden = db.ordenes.Find(id);
        //    ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
        //    return View(orden);
        //}

        ////
        //// POST: /AreaContable/Ordenes/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Orden orden)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(orden).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
        //    return View(orden);
        //}

        ////
        //// GET: /AreaContable/Ordenes/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    Orden orden = db.ordenes.Find(id);
        //    return View(orden);
        //}

        ////
        //// POST: /AreaContable/Ordenes/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    Orden orden = db.ordenes.Find(id);
        //    db.ordenes.Remove(orden);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
//    }
//}