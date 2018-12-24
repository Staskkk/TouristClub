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
    public class CampingRoutesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: CampingRoutes
        public ActionResult Index()
        {
            var campingRoutes = db.CampingRoutes.Include(c => c.AreaType);
            return View(campingRoutes.ToList());
        }

        // GET: CampingRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoute campingRoute = db.CampingRoutes.Find(id);
            if (campingRoute == null)
            {
                return HttpNotFound();
            }
            return View(campingRoute);
        }

        // GET: CampingRoutes/Create
        public ActionResult Create()
        {
            ViewBag.AreaTypeId = new SelectList(db.AreaTypes, "Id", "Name");
            return View();
        }

        // POST: CampingRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaTypeId,DurationDays,LengthKm,Description")] CampingRoute campingRoute)
        {
            if (ModelState.IsValid)
            {
                db.CampingRoutes.Add(campingRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaTypeId = new SelectList(db.AreaTypes, "Id", "Name", campingRoute.AreaTypeId);
            return View(campingRoute);
        }

        // GET: CampingRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoute campingRoute = db.CampingRoutes.Find(id);
            if (campingRoute == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaTypeId = new SelectList(db.AreaTypes, "Id", "Name", campingRoute.AreaTypeId);
            return View(campingRoute);
        }

        // POST: CampingRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaTypeId,DurationDays,LengthKm,Description")] CampingRoute campingRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campingRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaTypeId = new SelectList(db.AreaTypes, "Id", "Name", campingRoute.AreaTypeId);
            return View(campingRoute);
        }

        // GET: CampingRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoute campingRoute = db.CampingRoutes.Find(id);
            if (campingRoute == null)
            {
                return HttpNotFound();
            }
            return View(campingRoute);
        }

        // POST: CampingRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampingRoute campingRoute = db.CampingRoutes.Find(id);
            db.CampingRoutes.Remove(campingRoute);
            db.SaveChanges();
            return RedirectToAction("Index");
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
