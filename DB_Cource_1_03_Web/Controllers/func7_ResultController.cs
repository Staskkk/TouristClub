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
    public class func7_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func7_Result
        public ActionResult Index(Func7Input func7Input)
        {
            return View(db.func7(func7Input.TrainerName, func7Input.Section, func7Input.ActivityType, func7Input.StartDate, func7Input.EndDate));
        }

        // GET: func7_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func7Input func7Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func7Input);
            }

            return View(func7Input);
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
