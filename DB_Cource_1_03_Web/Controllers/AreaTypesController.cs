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
    public class AreaTypesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: AreaTypes
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<AreaType>());
            }
            return View(db.AreaTypes.ToList());
        }

        // GET: AreaTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaType areaType = db.AreaTypes.Find(id);
            if (areaType == null)
            {
                return HttpNotFound();
            }
            return View(areaType);
        }

        // GET: AreaTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AreaType areaType)
        {
            if (ModelState.IsValid)
            {
                db.AreaTypes.Add(areaType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaType);
        }

        // GET: AreaTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaType areaType = db.AreaTypes.Find(id);
            if (areaType == null)
            {
                return HttpNotFound();
            }
            return View(areaType);
        }

        // POST: AreaTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AreaType areaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaType);
        }

        // GET: AreaTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaType areaType = db.AreaTypes.Find(id);
            if (areaType == null)
            {
                return HttpNotFound();
            }
            return View(areaType);
        }

        // POST: AreaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaType areaType = db.AreaTypes.Find(id);
            db.AreaTypes.Remove(areaType);
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
