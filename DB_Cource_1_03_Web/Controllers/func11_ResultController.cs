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
    public class func11_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func11_Result
        public ActionResult Index(Func11Input func11Input)
        {
            return View(db.func11(func11Input.IsInstructorTrainer, func11Input.InstructorLevel,
                func11Input.CampingTripsCount, func11Input.CampingTripId, func11Input.CampingRouteId,
                func11Input.CampingPlace));
        }

        // GET: func11_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func11Input func11Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func11Input);
            }

            return View(func11Input);
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
