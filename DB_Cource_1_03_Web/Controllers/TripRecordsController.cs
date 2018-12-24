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
    public class TripRecordsController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TripRecords
        public ActionResult Index()
        {
            var tripRecords = db.TripRecords.Include(t => t.CampingPlace).Include(t => t.CampingTrip);
            return View(tripRecords.ToList());
        }

        // GET: TripRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = db.TripRecords.Find(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            return View(tripRecord);
        }

        // GET: TripRecords/Create
        public ActionResult Create()
        {
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name");
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id");
            return View();
        }

        // POST: TripRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CampingTripId,CampingPlaceId,StartTime,EndTime,Comments")] TripRecord tripRecord)
        {
            if (ModelState.IsValid)
            {
                db.TripRecords.Add(tripRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", tripRecord.CampingPlaceId);
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", tripRecord.CampingTripId);
            return View(tripRecord);
        }

        // GET: TripRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = db.TripRecords.Find(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", tripRecord.CampingPlaceId);
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", tripRecord.CampingTripId);
            return View(tripRecord);
        }

        // POST: TripRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CampingTripId,CampingPlaceId,StartTime,EndTime,Comments")] TripRecord tripRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", tripRecord.CampingPlaceId);
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", tripRecord.CampingTripId);
            return View(tripRecord);
        }

        // GET: TripRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripRecord tripRecord = db.TripRecords.Find(id);
            if (tripRecord == null)
            {
                return HttpNotFound();
            }
            return View(tripRecord);
        }

        // POST: TripRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripRecord tripRecord = db.TripRecords.Find(id);
            db.TripRecords.Remove(tripRecord);
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
