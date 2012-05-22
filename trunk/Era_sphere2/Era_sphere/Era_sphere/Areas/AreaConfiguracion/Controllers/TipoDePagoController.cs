using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Era_sphere.Areas.AreaConfiguracion.Models.Fiscal;
using System.Data;

namespace Era_sphere.Areas.AreaConfiguracion.Controllers
{
    public class TipoDePagoController : Controller
    {
        TipoDePagoContext db = new TipoDePagoContext();

        //
        // GET: /AreaConfiguracion/TipoDePago/

        public ActionResult Index()
        {
            return View(db.tipo_de_pagos);
        }

        //
        // GET: /AreaConfiguracion/TipoDePago/Details/5

        public ActionResult Details(int id)
        {
            return View(db.tipo_de_pagos.Find(id));
        }

        //
        // GET: /AreaConfiguracion/TipoDePago/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AreaConfiguracion/TipoDePago/Create

        [HttpPost]
        public ActionResult Create(TipoDePago tipopago)
        {
            try
            {
                // TODO: Add insert logic here
                db.tipo_de_pagos.Add(tipopago);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /AreaConfiguracion/TipoDePago/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(db.tipo_de_pagos.Find(id));
        }

        //
        // POST: /AreaConfiguracion/TipoDePago/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, TipoDePago tipopago)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(tipopago).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AreaConfiguracion/TipoDePago/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(db.tipo_de_pagos.Find(id));
        }

        //
        // POST: /AreaConfiguracion/TipoDePago/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TipoDePago tipopago)
        {
            try
            {
                // TODO: Add delete logic here
                db.Entry(tipopago).State = EntityState.Deleted;
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
