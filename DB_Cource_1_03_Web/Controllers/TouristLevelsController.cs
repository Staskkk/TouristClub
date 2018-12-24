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
    public class TouristLevelsController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristLevels
        public ActionResult Index()
        {
            return View(db.TouristLevels.ToList());
        }

        // GET: TouristLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristLevel touristLevel = db.TouristLevels.Find(id);
            if (touristLevel == null)
            {
                return HttpNotFound();
            }
            return View(touristLevel);
        }

        // GET: TouristLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TouristLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TouristLevel touristLevel)
        {
            if (ModelState.IsValid)
            {
                db.TouristLevels.Add(touristLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(touristLevel);
        }

        // GET: TouristLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristLevel touristLevel = db.TouristLevels.Find(id);
            if (touristLevel == null)
            {
                return HttpNotFound();
            }
            return View(touristLevel);
        }

        // POST: TouristLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TouristLevel touristLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(touristLevel);
        }

        // GET: TouristLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristLevel touristLevel = db.TouristLevels.Find(id);
            if (touristLevel == null)
            {
                return HttpNotFound();
            }
            return View(touristLevel);
        }

        // POST: TouristLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristLevel touristLevel = db.TouristLevels.Find(id);
            db.TouristLevels.Remove(touristLevel);
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
