using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_Cource_1_03_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tables()
        {
            ViewBag.Message = "Tables page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tourist club in Ukraine";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}