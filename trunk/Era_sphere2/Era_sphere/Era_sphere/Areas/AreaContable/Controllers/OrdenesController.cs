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
    public class OrdenesController : Controller
    {
        private EraSphereContext db = new EraSphereContext();

        //
        // GET: /AreaContable/Ordenes/

        public ViewResult Index()
        {
            var ordenes = db.ordenes.Include(o => o.empleado_solicita);
            return View(ordenes.ToList());
        }

        //
        // GET: /AreaContable/Ordenes/Details/5

        public ViewResult Details(int id)
        {
            Orden orden = db.ordenes.Find(id);
            return View(orden);
        }

        //
        // GET: /AreaContable/Ordenes/Create

        public ActionResult Create()
        {
            ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion");
            return View();
        } 

        //
        // POST: /AreaContable/Ordenes/Create

        [HttpPost]
        public ActionResult Create(Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.ordenes.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
            return View(orden);
        }
        
        //
        // GET: /AreaContable/Ordenes/Edit/5
 
        public ActionResult Edit(int id)
        {
            Orden orden = db.ordenes.Find(id);
            ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
            return View(orden);
        }

        //
        // POST: /AreaContable/Ordenes/Edit/5

        [HttpPost]
        public ActionResult Edit(Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empleado_solicitaID = new SelectList(db.empleados, "ID", "descripcion", orden.empleado_solicitaID);
            return View(orden);
        }

        //
        // GET: /AreaContable/Ordenes/Delete/5
 
        public ActionResult Delete(int id)
        {
            Orden orden = db.ordenes.Find(id);
            return View(orden);
        }

        //
        // POST: /AreaContable/Ordenes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Orden orden = db.ordenes.Find(id);
            db.ordenes.Remove(orden);
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