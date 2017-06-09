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
    public class StorageUnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StorageUnits
        public ActionResult Index()
        {
            var storageUnits = db.StorageUnits.Include(s => s.Contracts);
            return View(storageUnits.ToList());
        }

        // GET: StorageUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageUnit storageUnit = db.StorageUnits.Find(id);
            if (storageUnit == null)
            {
                return HttpNotFound();
            }
            return View(storageUnit);
        }

        // GET: StorageUnits/Create
        public ActionResult Create()
        {
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id");
            return View();
        }

        // POST: StorageUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UnitNumber,UnitDescription,TermAtRate,RentalRate,ContractId")] StorageUnit storageUnit)
        {
            if (ModelState.IsValid)
            {
                db.StorageUnits.Add(storageUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", storageUnit.ContractId);
            return View(storageUnit);
        }

        // GET: StorageUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageUnit storageUnit = db.StorageUnits.Find(id);
            if (storageUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", storageUnit.ContractId);
            return View(storageUnit);
        }

        // POST: StorageUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UnitNumber,UnitDescription,TermAtRate,RentalRate,ContractId")] StorageUnit storageUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storageUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "Id", "Id", storageUnit.ContractId);
            return View(storageUnit);
        }

        // GET: StorageUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageUnit storageUnit = db.StorageUnits.Find(id);
            if (storageUnit == null)
            {
                return HttpNotFound();
            }
            return View(storageUnit);
        }

        // POST: StorageUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StorageUnit storageUnit = db.StorageUnits.Find(id);
            db.StorageUnits.Remove(storageUnit);
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
