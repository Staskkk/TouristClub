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
    public class TouristCampingTripInfoesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristCampingTripInfoes
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<TouristCampingTripInfo>());
            }
            var touristCampingTripInfoes = db.TouristCampingTripInfoes.Include(t => t.CampingTrip).Include(t => t.Tourist);
            return View(touristCampingTripInfoes.ToList());
        }

        // GET: TouristCampingTripInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCampingTripInfo touristCampingTripInfo = db.TouristCampingTripInfoes.Find(id);
            if (touristCampingTripInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristCampingTripInfo);
        }

        // GET: TouristCampingTripInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id");
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name");
            return View();
        }

        // POST: TouristCampingTripInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TouristId,CampingTripId")] TouristCampingTripInfo touristCampingTripInfo)
        {
            if (ModelState.IsValid)
            {
                db.TouristCampingTripInfoes.Add(touristCampingTripInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", touristCampingTripInfo.CampingTripId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCampingTripInfo.TouristId);
            return View(touristCampingTripInfo);
        }

        // GET: TouristCampingTripInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCampingTripInfo touristCampingTripInfo = db.TouristCampingTripInfoes.Find(id);
            if (touristCampingTripInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", touristCampingTripInfo.CampingTripId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCampingTripInfo.TouristId);
            return View(touristCampingTripInfo);
        }

        // POST: TouristCampingTripInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TouristId,CampingTripId")] TouristCampingTripInfo touristCampingTripInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristCampingTripInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampingTripId = new SelectList(db.CampingTrips, "Id", "Id", touristCampingTripInfo.CampingTripId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCampingTripInfo.TouristId);
            return View(touristCampingTripInfo);
        }

        // GET: TouristCampingTripInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCampingTripInfo touristCampingTripInfo = db.TouristCampingTripInfoes.Find(id);
            if (touristCampingTripInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristCampingTripInfo);
        }

        // POST: TouristCampingTripInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristCampingTripInfo touristCampingTripInfo = db.TouristCampingTripInfoes.Find(id);
            db.TouristCampingTripInfoes.Remove(touristCampingTripInfo);
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
