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
    public class TouristAssigmentsController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristAssigments
        public ActionResult Index()
        {
            var touristAssigments = db.TouristAssigments.Include(t => t.Section).Include(t => t.Tourist).Include(t => t.TouristPost).Include(t => t.TouristLevel);
            return View(touristAssigments.ToList());
        }

        // GET: TouristAssigments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAssigment touristAssigment = db.TouristAssigments.Find(id);
            if (touristAssigment == null)
            {
                return HttpNotFound();
            }
            return View(touristAssigment);
        }

        // GET: TouristAssigments/Create
        public ActionResult Create()
        {
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name");
            ViewBag.TouristPostId = new SelectList(db.TouristPosts, "Id", "Name");
            ViewBag.TouristLevelId = new SelectList(db.TouristLevels, "Id", "Name");
            return View();
        }

        // POST: TouristAssigments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TouristId,TouristPostId,SectionId,TouristLevelId,StartDate,EndDate")] TouristAssigment touristAssigment)
        {
            if (ModelState.IsValid)
            {
                db.TouristAssigments.Add(touristAssigment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", touristAssigment.SectionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristAssigment.TouristId);
            ViewBag.TouristPostId = new SelectList(db.TouristPosts, "Id", "Name", touristAssigment.TouristPostId);
            ViewBag.TouristLevelId = new SelectList(db.TouristLevels, "Id", "Name", touristAssigment.TouristLevelId);
            return View(touristAssigment);
        }

        // GET: TouristAssigments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAssigment touristAssigment = db.TouristAssigments.Find(id);
            if (touristAssigment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", touristAssigment.SectionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristAssigment.TouristId);
            ViewBag.TouristPostId = new SelectList(db.TouristPosts, "Id", "Name", touristAssigment.TouristPostId);
            ViewBag.TouristLevelId = new SelectList(db.TouristLevels, "Id", "Name", touristAssigment.TouristLevelId);
            return View(touristAssigment);
        }

        // POST: TouristAssigments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TouristId,TouristPostId,SectionId,TouristLevelId,StartDate,EndDate")] TouristAssigment touristAssigment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristAssigment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", touristAssigment.SectionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristAssigment.TouristId);
            ViewBag.TouristPostId = new SelectList(db.TouristPosts, "Id", "Name", touristAssigment.TouristPostId);
            ViewBag.TouristLevelId = new SelectList(db.TouristLevels, "Id", "Name", touristAssigment.TouristLevelId);
            return View(touristAssigment);
        }

        // GET: TouristAssigments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAssigment touristAssigment = db.TouristAssigments.Find(id);
            if (touristAssigment == null)
            {
                return HttpNotFound();
            }
            return View(touristAssigment);
        }

        // POST: TouristAssigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristAssigment touristAssigment = db.TouristAssigments.Find(id);
            db.TouristAssigments.Remove(touristAssigment);
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
