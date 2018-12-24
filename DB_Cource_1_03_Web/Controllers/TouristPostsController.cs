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
    public class TouristPostsController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: TouristPosts
        public ActionResult Index()
        {
            return View(db.TouristPosts.ToList());
        }

        // GET: TouristPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPost touristPost = db.TouristPosts.Find(id);
            if (touristPost == null)
            {
                return HttpNotFound();
            }
            return View(touristPost);
        }

        // GET: TouristPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TouristPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TouristPost touristPost)
        {
            if (ModelState.IsValid)
            {
                db.TouristPosts.Add(touristPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(touristPost);
        }

        // GET: TouristPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPost touristPost = db.TouristPosts.Find(id);
            if (touristPost == null)
            {
                return HttpNotFound();
            }
            return View(touristPost);
        }

        // POST: TouristPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TouristPost touristPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(touristPost);
        }

        // GET: TouristPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPost touristPost = db.TouristPosts.Find(id);
            if (touristPost == null)
            {
                return HttpNotFound();
            }
            return View(touristPost);
        }

        // POST: TouristPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristPost touristPost = db.TouristPosts.Find(id);
            db.TouristPosts.Remove(touristPost);
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
