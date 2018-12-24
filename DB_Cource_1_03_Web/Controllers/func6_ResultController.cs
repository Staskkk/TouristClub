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
    public class func6_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func6_Result
        public ActionResult Index(Func6Input func6Input)
        {
            return View(db.func6(func6Input.BirthDate, func6Input.Age, func6Input.AssignmentYear));
        }

        // GET: func6_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func6Input func6Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func6Input);
            }

            return View(func6Input);
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
