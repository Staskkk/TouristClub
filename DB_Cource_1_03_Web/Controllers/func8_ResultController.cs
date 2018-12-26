using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB_Cource_1_03_Web.Models;
using Newtonsoft.Json;

namespace DB_Cource_1_03_Web.Controllers
{
    public class func8_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func8_Result
        public ActionResult Index(Func8Input func8Input)
        {
            if (string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.User.Identity.Name))
            {
                return View(new List<func8_Result>());
            }
            var res = db.func8(func8Input.Section, func8Input.StartDate, func8Input.EndDate,
                func8Input.InstructorName, func8Input.GroupCount).ToList();
            Response.AppendCookie(new HttpCookie("Data", JsonConvert.SerializeObject(res)));
            return View(res);
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

        public ActionResult ExportPdf()
        {
            var data = JsonConvert.DeserializeObject<List<func8_Result>>(Request.Cookies["Data"].Value);
            if (data != null)
            {
                var res = MvcApplication.GetExportPdf(data, Server, Response);
                return File(res.Item1, res.Item2, res.Item3);
            }

            return Index(null);
        }
    }
}
