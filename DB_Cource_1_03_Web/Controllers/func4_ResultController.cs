using System;
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
    public class func4_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func4_Result
        public ActionResult Index(Func4Input func4Input)
        {
            return View(db.func4(func4Input.Group, func4Input.Date, func4Input.StartTime, func4Input.EndTime));
        }

        // GET: func4_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func4Input func4Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func4Input);
            }

            return View(func4Input);
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
