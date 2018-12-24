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
    public class TouristCompetitionInfoesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristCompetitionInfoes
        public ActionResult Index()
        {
            var touristCompetitionInfoes = db.TouristCompetitionInfoes.Include(t => t.Competition).Include(t => t.Tourist);
            return View(touristCompetitionInfoes.ToList());
        }

        // GET: TouristCompetitionInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCompetitionInfo touristCompetitionInfo = db.TouristCompetitionInfoes.Find(id);
            if (touristCompetitionInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristCompetitionInfo);
        }

        // GET: TouristCompetitionInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Description");
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name");
            return View();
        }

        // POST: TouristCompetitionInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TouristId,CompetitionId")] TouristCompetitionInfo touristCompetitionInfo)
        {
            if (ModelState.IsValid)
            {
                db.TouristCompetitionInfoes.Add(touristCompetitionInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Description", touristCompetitionInfo.CompetitionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCompetitionInfo.TouristId);
            return View(touristCompetitionInfo);
        }

        // GET: TouristCompetitionInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCompetitionInfo touristCompetitionInfo = db.TouristCompetitionInfoes.Find(id);
            if (touristCompetitionInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Description", touristCompetitionInfo.CompetitionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCompetitionInfo.TouristId);
            return View(touristCompetitionInfo);
        }

        // POST: TouristCompetitionInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TouristId,CompetitionId")] TouristCompetitionInfo touristCompetitionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristCompetitionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "Id", "Description", touristCompetitionInfo.CompetitionId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristCompetitionInfo.TouristId);
            return View(touristCompetitionInfo);
        }

        // GET: TouristCompetitionInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristCompetitionInfo touristCompetitionInfo = db.TouristCompetitionInfoes.Find(id);
            if (touristCompetitionInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristCompetitionInfo);
        }

        // POST: TouristCompetitionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristCompetitionInfo touristCompetitionInfo = db.TouristCompetitionInfoes.Find(id);
            db.TouristCompetitionInfoes.Remove(touristCompetitionInfo);
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
