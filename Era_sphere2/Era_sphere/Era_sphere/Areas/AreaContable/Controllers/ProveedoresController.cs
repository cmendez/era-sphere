using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models;
using Era_sphere.Areas.AreaEventos.Models.Evento;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Controllers
{ 
    public class ProveedoresController : Controller
    {
        private EraSphereContext db = new EraSphereContext();

        //
        // GET: /AreaContable/Proveedores/

        public ViewResult Index()
        {
            return View(db.proveedores.ToList());
        }

        //
        // GET: /AreaContable/Proveedores/Details/5

        public ViewResult Details(int id)
        {
            Proveedor proveedor = db.proveedores.Find(id);
            return View(proveedor);
        }

        //
        // GET: /AreaContable/Proveedores/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AreaContable/Proveedores/Create

        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedores.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(proveedor);
        }
        
        //
        // GET: /AreaContable/Proveedores/Edit/5
 
        public ActionResult Edit(int id)
        {
            Proveedor proveedor = db.proveedores.Find(id);
            return View(proveedor);
        }

        //
        // POST: /AreaContable/Proveedores/Edit/5

        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        //
        // GET: /AreaContable/Proveedores/Delete/5
 
        public ActionResult Delete(int id)
        {
            Proveedor proveedor = db.proveedores.Find(id);
            return View(proveedor);
        }

        //
        // POST: /AreaContable/Proveedores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Proveedor proveedor = db.proveedores.Find(id);
            db.proveedores.Remove(proveedor);
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