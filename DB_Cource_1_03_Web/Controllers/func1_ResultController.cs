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
    public class func1_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func1_Result
        public ActionResult Index(Func1Input func1Input)
        {
            return View(db.func1(func1Input.Section, func1Input.Group, func1Input.Sex, func1Input.BirthDate, func1Input.Age));
        }

        // GET: func1_Result/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Func1Input func1Input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", func1Input);
            }

            return View(func1Input);
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
