using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HazeltineStorage.Models;

namespace HazeltineStorage.Controllers
{
    public class ActivityLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivityLogs
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.Customer).Include(a => a.MessageType).Include(a => a.User);
            return View(activities.ToList());
        }

        // GET: ActivityLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.Activities.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // GET: ActivityLogs/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName");
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId");
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "MessageType");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: ActivityLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,LogDate,MessageId,Notes,UserId")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activityLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", activityLog.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", activityLog.CustomerId);
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "MessageType", activityLog.MessageId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", activityLog.UserId);
            return View(activityLog);
        }

        // GET: ActivityLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.Activities.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", activityLog.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", activityLog.CustomerId);
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "MessageType", activityLog.MessageId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", activityLog.UserId);
            return View(activityLog);
        }

        // POST: ActivityLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,LogDate,MessageId,Notes,UserId")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", activityLog.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", activityLog.CustomerId);
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "MessageType", activityLog.MessageId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", activityLog.UserId);
            return View(activityLog);
        }

        // GET: ActivityLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.Activities.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // POST: ActivityLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityLog activityLog = db.Activities.Find(id);
            db.Activities.Remove(activityLog);
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
