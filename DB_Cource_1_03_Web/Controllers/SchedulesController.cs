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
    public class SchedulesController : Controller
    {
        private sp19TourClubEntities db = new sp19TourClubEntities();

        // GET: Schedules
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.Name != "Admin")
            {
                return View(new List<Schedule>());
            }
            var schedules = db.Schedules.Include(s => s.ActivityType).Include(s => s.DayOfWeek).Include(s => s.Group).Include(s => s.Tourist);
            return View(schedules.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name");
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.TrainerId = new SelectList(db.Tourists, "Id", "Name");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupId,ActivityTypeId,DayOfWeekId,Address,StartTime,EndTime,TrainerId,StartDate,EndDate")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", schedule.ActivityTypeId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.TrainerId = new SelectList(db.Tourists, "Id", "Name", schedule.TrainerId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", schedule.ActivityTypeId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.TrainerId = new SelectList(db.Tourists, "Id", "Name", schedule.TrainerId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupId,ActivityTypeId,DayOfWeekId,Address,StartTime,EndTime,TrainerId,StartDate,EndDate")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Name", schedule.ActivityTypeId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.TrainerId = new SelectList(db.Tourists, "Id", "Name", schedule.TrainerId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
