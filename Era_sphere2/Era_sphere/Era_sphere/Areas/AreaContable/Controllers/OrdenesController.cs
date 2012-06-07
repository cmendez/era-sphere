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
            foreach (Orden o in os)
            {
                o.total = 0;
                o.nro_lineas = 0;
                foreach (OrdenLinea ol in o.ordenlineas)
                {
                    o.total += ol.SubTotal;
                    o.nro_lineas++;
                }
                ovs.Add(new OrdenView(o));
            }
            return View("IndexOrdenes", new GridModel(ovs));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Update(OrdenView ov)
        {
            Orden ord = db.ordenes.Find(ov.ID);
            ord.estado = ov.estadoID;
            db.Entry(ord).State = EntityState.Modified;
            db.SaveChanges();

            /**/
            List<Orden> os = db.ordenes.ToList();
            List<OrdenView> ovs = new List<OrdenView>();
            foreach (Orden o in os)
            {
                o.total = 0;
                o.nro_lineas = 0;
                foreach (OrdenLinea ol in o.ordenlineas)
                {
                    o.total += ol.SubTotal;
                    o.nro_lineas++;
                }
                ovs.Add(new OrdenView(o));
            }
            return View("IndexOrdenes", new GridModel(ovs));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Delete(int? id)
        {
            db.ordenes.Remove(db.ordenes.Find(id));
            db.SaveChanges();

            List<Orden> os = db.ordenes.ToList();
            List<OrdenView> ovs = new List<OrdenView>();
            foreach (Orden o in os) ovs.Add(new OrdenView(o));
            return View("IndexOrdenes", new GridModel(ovs));
            //return View("Index", new GridModel(db.ordenes.ToList()));
        }

        public ActionResult agregar(int? oid)
        {
            if (oid == null)
            {
                Orden o = new Orden
                {
                    estado = 0,
                    fechaRegistro = DateTime.Today,
                    totalIGV = 0,
                    total = 0,
                    ordenlineas = new List<OrdenLinea>()
                };
                db.ordenes.Add(o);
                db.SaveChanges();
                ViewData["oid"] = o.ID;
            }
            else
                ViewData["oid"] = oid;

            return View("AgregarOrden");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult SelectLineas(int oid)
        {
            ICollection<OrdenLineaView> olvs = new List<OrdenLineaView>();
            ICollection<OrdenLinea> ols = db.ordenes.Find(oid).ordenlineas;
            foreach (OrdenLinea ol in ols) olvs.Add(new OrdenLineaView(ol));

            ViewData["oid"] = oid;
            return View("AgregarOrden", new GridModel(olvs));
        }
        [AcceptVerbs(HttpVerbs.Post)]

        [GridAction]
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
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult DeleteLinea(int? id, int? oid)
        {
            db.ordeneslineas.Remove(db.ordeneslineas.Find(id));
            db.SaveChanges();

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