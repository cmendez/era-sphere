﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}