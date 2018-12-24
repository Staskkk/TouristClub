﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB_Cource_1_03_Web.Models;

namespace DB_Cource_1_03_Web.Controllers
{
    public class func2_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func2_Result
        public ActionResult Index(Func2Input func2Input)
        {
            return View(db.func2(func2Input.Section, func2Input.Sex, func2Input.Age, func2Input.SpecActivity));
        }

        // GET: func2_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func2Input func2Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func2Input);
            }

            return View(func2Input);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}