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
    public class func7_ResultController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: func7_Result
        public ActionResult Index(Func7Input func7Input)
        {
            if (string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.User.Identity.Name))
            {
                return View(new List<func7_Result>());
            }
            var res = db.func7(func7Input.TrainerName, func7Input.Section, func7Input.ActivityType, func7Input.StartDate, func7Input.EndDate).ToList();
            Response.AppendCookie(new HttpCookie("Data", JsonConvert.SerializeObject(res)));
            return View(res);
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

        public ActionResult ExportPdf()
        {
            var data = JsonConvert.DeserializeObject<List<func7_Result>>(Request.Cookies["Data"].Value);
            if (data != null)
            {
                var res = MvcApplication.GetExportPdf(data, Server, Response);
                return File(res.Item1, res.Item2, res.Item3);
            }

            return Index(null);
        }
    }
}
