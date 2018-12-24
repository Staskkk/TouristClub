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
    public class func8_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func8_Result
        public ActionResult Index(Func8Input func8Input)
        {
            return View(db.func8(func8Input.Section, func8Input.StartDate, func8Input.EndDate,
                func8Input.InstructorName, func8Input.GroupCount));
        }

        // GET: func8_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func8Input func8Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func8Input);
            }

            return View(func8Input);
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
