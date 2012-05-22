using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using System.Data;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class MonedaController : Controller
    {

        MonedaContext db = new MonedaContext();

        //
        // GET: /Moneda/

        public ActionResult Index()
        {
            return View(db.monedas);
        }

        //
        // GET: /Moneda/Details/5

        public ActionResult Details(int id)
        {
            return View(db.monedas.Find(id));
        }

        //
        // GET: /Moneda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Moneda/Create

        [HttpPost]
        public ActionResult Create(Moneda moneda)
        {
            try
            {
                // TODO: Add insert logic here
                db.monedas.Add(moneda);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Moneda/Edit/5

        public ActionResult Edit(int id)
        {
            return View(db.monedas.Find(id));
        }

        //
        // POST: /Moneda/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Moneda moneda)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(moneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Moneda/Delete/5

        public ActionResult Delete(int id)
        {
            return View(db.monedas.Find(id));
        }

        //
        // POST: /Moneda/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Moneda moneda)
        {
            try
            {
                // TODO: Add delete logic here
                db.Entry(moneda).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    
}
