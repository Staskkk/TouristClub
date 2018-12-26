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
    public class CampingPlacesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: CampingPlaces
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<CampingPlace>());
            }
            return View(db.CampingPlaces.ToList());
        }

        // GET: CampingPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingPlace campingPlace = db.CampingPlaces.Find(id);
            if (campingPlace == null)
            {
                return HttpNotFound();
            }
            return View(campingPlace);
        }

        // GET: CampingPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampingPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Latitude,Longitude")] CampingPlace campingPlace)
        {
            if (ModelState.IsValid)
            {
                db.CampingPlaces.Add(campingPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campingPlace);
        }

        // GET: CampingPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingPlace campingPlace = db.CampingPlaces.Find(id);
            if (campingPlace == null)
            {
                return HttpNotFound();
            }
            return View(campingPlace);
        }

        // POST: CampingPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Latitude,Longitude")] CampingPlace campingPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campingPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campingPlace);
        }

        // GET: CampingPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampingPlace campingPlace = db.CampingPlaces.Find(id);
            if (campingPlace == null)
            {
                return HttpNotFound();
            }
            return View(campingPlace);
        }

        // POST: CampingPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampingPlace campingPlace = db.CampingPlaces.Find(id);
            db.CampingPlaces.Remove(campingPlace);
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
