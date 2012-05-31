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

namespace Era_sphere.Areas.AreaContable.Controllers
{ 
    public class Proveedor_x_ProductoController : Controller
    {
        private EraSphereContext db = new EraSphereContext();

        //
        // GET: /AreaContabilidad/Proveedor_x_Producto/

        public ViewResult Index()
        {
            var p_x_p = db.p_x_p.Include(p => p.producto).Include(p => p.proveedor);
            return View(p_x_p.ToList());
        }

        //
        // GET: /AreaContabilidad/Proveedor_x_Producto/Details/5

        public ViewResult Details(int id)
        {
            proveedor_x_producto proveedor_x_producto = db.p_x_p.Find(id);
            return View(proveedor_x_producto);
        }

        //
        // GET: /AreaContabilidad/Proveedor_x_Producto/Create

        public ActionResult Create()
        {
            ViewBag.productoID = new SelectList(db.productos, "ID", "descripcion");
            ViewBag.proveedorID = new SelectList(db.proveedores, "ID", "descripcion");
            return View();
        } 

        //
        // POST: /AreaContabilidad/Proveedor_x_Producto/Create

        [HttpPost]
        public ActionResult Create(proveedor_x_producto proveedor_x_producto)
        {
            if (ModelState.IsValid)
            {
                db.p_x_p.Add(proveedor_x_producto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.productoID = new SelectList(db.productos, "ID", "descripcion", proveedor_x_producto.productoID);
            ViewBag.proveedorID = new SelectList(db.proveedores, "ID", "descripcion", proveedor_x_producto.proveedorID);
            return View(proveedor_x_producto);
        }
        
        //
        // GET: /AreaContabilidad/Proveedor_x_Producto/Edit/5
 
        public ActionResult Edit(int id)
        {
            proveedor_x_producto proveedor_x_producto = db.p_x_p.Find(id);
            ViewBag.productoID = new SelectList(db.productos, "ID", "descripcion", proveedor_x_producto.productoID);
            ViewBag.proveedorID = new SelectList(db.proveedores, "ID", "descripcion", proveedor_x_producto.proveedorID);
            return View(proveedor_x_producto);
        }

        //
        // POST: /AreaContabilidad/Proveedor_x_Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(proveedor_x_producto proveedor_x_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor_x_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productoID = new SelectList(db.productos, "ID", "descripcion", proveedor_x_producto.productoID);
            ViewBag.proveedorID = new SelectList(db.proveedores, "ID", "descripcion", proveedor_x_producto.proveedorID);
            return View(proveedor_x_producto);
        }

        //
        // GET: /AreaContabilidad/Proveedor_x_Producto/Delete/5
 
        public ActionResult Delete(int id)
        {
            proveedor_x_producto proveedor_x_producto = db.p_x_p.Find(id);
            return View(proveedor_x_producto);
        }

        //
        // POST: /AreaContabilidad/Proveedor_x_Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            proveedor_x_producto proveedor_x_producto = db.p_x_p.Find(id);
            db.p_x_p.Remove(proveedor_x_producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}