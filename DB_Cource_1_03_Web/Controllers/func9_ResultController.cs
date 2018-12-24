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
    public class func9_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func9_Result
        public ActionResult Index(Func9Input func9Input)
        {
            return View(db.func9(func9Input.CampingPlace, func9Input.MinLengthKm, func9Input.MinTouristLevel));
        }

        // GET: func9_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func9Input func9Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func9Input);
            }

            return View(func9Input);
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
