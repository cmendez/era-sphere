﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaContable.Models.Productos;
using Era_sphere.Areas.AreaEventos.Models.Evento;
using Era_sphere.Generics;

namespace Era_sphere.Areas.AreaContable.Controllers
{ 
    public class ProductoController : Controller
    {
        private EraSphereContext db = new EraSphereContext();

        //
        // GET: /AreaContable/Producto/

        public ViewResult Index()
        {
            return View(db.productos.ToList());
        }

        //
        // GET: /AreaContable/Producto/Details/5

        public ViewResult Details(int id)
        {
            Producto producto = db.productos.Find(id);
            return View(producto);
        }

        //
        // GET: /AreaContable/Producto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AreaContable/Producto/Create

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(producto);
        }
        
        //
        // GET: /AreaContable/Producto/Edit/5
 
        public ActionResult Edit(int id)
        {
            Producto producto = db.productos.Find(id);
            return View(producto);
        }

        //
        // POST: /AreaContable/Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        //
        // GET: /AreaContable/Producto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Producto producto = db.productos.Find(id);
            return View(producto);
        }

        //
        // POST: /AreaContable/Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Producto producto = db.productos.Find(id);
            db.productos.Remove(producto);
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