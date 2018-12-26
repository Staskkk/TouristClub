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
    public class CampingRoutePlaceInfoesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: CampingRoutePlaceInfoes
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<CampingRoutePlaceInfo>());
            }
            var campingRoutePlaceInfoes = db.CampingRoutePlaceInfoes.Include(c => c.CampingPlace).Include(c => c.CampingRoute);
            return View(campingRoutePlaceInfoes.ToList());
        }

        // GET: CampingRoutePlaceInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoutePlaceInfo campingRoutePlaceInfo = db.CampingRoutePlaceInfoes.Find(id);
            if (campingRoutePlaceInfo == null)
            {
                return HttpNotFound();
            }
            return View(campingRoutePlaceInfo);
        }

        // GET: CampingRoutePlaceInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name");
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description");
            return View();
        }

        // POST: CampingRoutePlaceInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CampingRouteId,CampingPlaceId")] CampingRoutePlaceInfo campingRoutePlaceInfo)
        {
            if (ModelState.IsValid)
            {
                db.CampingRoutePlaceInfoes.Add(campingRoutePlaceInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", campingRoutePlaceInfo.CampingPlaceId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingRoutePlaceInfo.CampingRouteId);
            return View(campingRoutePlaceInfo);
        }

        // GET: CampingRoutePlaceInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoutePlaceInfo campingRoutePlaceInfo = db.CampingRoutePlaceInfoes.Find(id);
            if (campingRoutePlaceInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", campingRoutePlaceInfo.CampingPlaceId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingRoutePlaceInfo.CampingRouteId);
            return View(campingRoutePlaceInfo);
        }

        // POST: CampingRoutePlaceInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CampingRouteId,CampingPlaceId")] CampingRoutePlaceInfo campingRoutePlaceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campingRoutePlaceInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampingPlaceId = new SelectList(db.CampingPlaces, "Id", "Name", campingRoutePlaceInfo.CampingPlaceId);
            ViewBag.CampingRouteId = new SelectList(db.CampingRoutes, "Id", "Description", campingRoutePlaceInfo.CampingRouteId);
            return View(campingRoutePlaceInfo);
        }

        // GET: CampingRoutePlaceInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingRoutePlaceInfo campingRoutePlaceInfo = db.CampingRoutePlaceInfoes.Find(id);
            if (campingRoutePlaceInfo == null)
            {
                return HttpNotFound();
            }
            return View(campingRoutePlaceInfo);
        }

        // POST: CampingRoutePlaceInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampingRoutePlaceInfo campingRoutePlaceInfo = db.CampingRoutePlaceInfoes.Find(id);
            db.CampingRoutePlaceInfoes.Remove(campingRoutePlaceInfo);
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
