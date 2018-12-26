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
    public class TouristGroupInfoesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristGroupInfoes
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<TouristGroupInfo>());
            }
            var touristGroupInfoes = db.TouristGroupInfoes.Include(t => t.Group).Include(t => t.Tourist);
            return View(touristGroupInfoes.ToList());
        }

        // GET: TouristGroupInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristGroupInfo touristGroupInfo = db.TouristGroupInfoes.Find(id);
            if (touristGroupInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristGroupInfo);
        }

        // GET: TouristGroupInfoes/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name");
            return View();
        }

        // POST: TouristGroupInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TouristId,GroupId,StartDate,EndDate")] TouristGroupInfo touristGroupInfo)
        {
            if (ModelState.IsValid)
            {
                db.TouristGroupInfoes.Add(touristGroupInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", touristGroupInfo.GroupId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristGroupInfo.TouristId);
            return View(touristGroupInfo);
        }

        // GET: TouristGroupInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristGroupInfo touristGroupInfo = db.TouristGroupInfoes.Find(id);
            if (touristGroupInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", touristGroupInfo.GroupId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristGroupInfo.TouristId);
            return View(touristGroupInfo);
        }

        // POST: TouristGroupInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TouristId,GroupId,StartDate,EndDate")] TouristGroupInfo touristGroupInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristGroupInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", touristGroupInfo.GroupId);
            ViewBag.TouristId = new SelectList(db.Tourists, "Id", "Name", touristGroupInfo.TouristId);
            return View(touristGroupInfo);
        }

        // GET: TouristGroupInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristGroupInfo touristGroupInfo = db.TouristGroupInfoes.Find(id);
            if (touristGroupInfo == null)
            {
                return HttpNotFound();
            }
            return View(touristGroupInfo);
        }

        // POST: TouristGroupInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristGroupInfo touristGroupInfo = db.TouristGroupInfoes.Find(id);
            db.TouristGroupInfoes.Remove(touristGroupInfo);
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
