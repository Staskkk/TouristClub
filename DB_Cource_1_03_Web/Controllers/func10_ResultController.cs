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
    public class func10_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func10_Result
        public ActionResult Index(Func10Input func10Input)
        {
            return View(db.func10(func10Input.Section, func10Input.Group, func10Input.AllowedTripActivityType));
        }

        // GET: func10_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func10Input func10Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func10Input);
            }

            return View(func10Input);
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
