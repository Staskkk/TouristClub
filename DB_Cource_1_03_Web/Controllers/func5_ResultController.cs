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
    public class func5_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func5_Result
        public ActionResult Index(Func5Input func5Input)
        {
            return View(db.func5(func5Input.Section, func5Input.Group, func5Input.TripCount, func5Input.CampingTripId,
                func5Input.StartDate, func5Input.EndDate, func5Input.CampingRouteId,
                func5Input.CampingPlace, func5Input.TouristLevel));
        }

        // GET: func5_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func5Input func5Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func5Input);
            }

            return View(func5Input);
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
