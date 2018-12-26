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
    public class CampingTripsController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: CampingTrips
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<CampingTrip>());
            }
            var campingTrips = db.CampingTrips.Include(c => c.ActivityType).Include(c => c.CampingRoute).Include(c => c.Tourist).Include(c => c.TouristLevel);
            return View(campingTrips.ToList());
        }

        // GET: CampingTrips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingTrip campingTrip = db.CampingTrips.Find(id);
            if (campingTrip == null)
            {
                return HttpNotFound();
            }
            return View(campingTrip);
        }

        // GET: CampingTrips/Create
        public ActionResult Create()
        {
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name");
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description");
            ViewBag.InstructorId = new SelectList(db.Tourists, "Id", "Name");
            ViewBag.TouristMinLevelId = new SelectList(db.TouristLevels, "Id", "Name");
            return View();
        }

        // POST: CampingTrips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CampingRouteId,TouristMinLevelId,InstructorId,ActivityTypeId,IsPlanned,StartDate,EndDate")] CampingTrip campingTrip)
        {
            if (ModelState.IsValid)
            {
                db.CampingTrips.Add(campingTrip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", campingTrip.ActivityTypeId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingTrip.CampingRouteId);
            ViewBag.InstructorId = new SelectList(db.Tourists, "Id", "Name", campingTrip.InstructorId);
            ViewBag.TouristMinLevelId = new SelectList(db.TouristLevels, "Id", "Name", campingTrip.TouristMinLevelId);
            return View(campingTrip);
        }

        // GET: CampingTrips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingTrip campingTrip = db.CampingTrips.Find(id);
            if (campingTrip == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", campingTrip.ActivityTypeId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingTrip.CampingRouteId);
            ViewBag.InstructorId = new SelectList(db.Tourists, "Id", "Name", campingTrip.InstructorId);
            ViewBag.TouristMinLevelId = new SelectList(db.TouristLevels, "Id", "Name", campingTrip.TouristMinLevelId);
            return View(campingTrip);
        }

        // POST: CampingTrips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CampingRouteId,TouristMinLevelId,InstructorId,ActivityTypeId,IsPlanned,StartDate,EndDate")] CampingTrip campingTrip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campingTrip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", campingTrip.ActivityTypeId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingTrip.CampingRouteId);
            ViewBag.InstructorId = new SelectList(db.Tourists, "Id", "Name", campingTrip.InstructorId);
            ViewBag.TouristMinLevelId = new SelectList(db.TouristLevels, "Id", "Name", campingTrip.TouristMinLevelId);
            return View(campingTrip);
        }

        // GET: CampingTrips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingTrip campingTrip = db.CampingTrips.Find(id);
            if (campingTrip == null)
            {
                return HttpNotFound();
            }
            return View(campingTrip);
        }

        // POST: CampingTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampingTrip campingTrip = db.CampingTrips.Find(id);
            db.CampingTrips.Remove(campingTrip);
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
