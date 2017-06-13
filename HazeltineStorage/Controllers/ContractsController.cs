using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HazeltineStorage.Models;
using HazeltineStorage.ViewModels;

namespace HazeltineStorage.Controllers
{
    public class ContractsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Customer);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/DetailsReadOnly/5 - Read Only View for Customer
        public ActionResult DetailsReadOnly(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }


        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,StartDate,EndDate,DayOfMonthDue,DayOfMonthGracePeriodEnds,ContractTotal")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", contract.CustomerId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", contract.CustomerId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,StartDate,EndDate,DayOfMonthDue,DayOfMonthGracePeriodEnds,ContractTotal")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", contract.CustomerId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contracts/AddStorage/5 Add storage units to contract.
        public ActionResult AddStorage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);

            if (contract == null)
            {
                return HttpNotFound();
            }

            int customerId = contract.CustomerId;
            Customer customer = db.Customers.Find(customerId);
            var storageUnits = db.StorageUnits.ToList();

            var viewModel = new ContractBuilderViewModel
            //(contract, customer, storageUnits);
            {
                Contract = contract,
                Customer = customer,
                StorageUnits = storageUnits
            };

            //ViewBag.storageUnits = new SelectList(db.StorageUnits, "Id", "UnitNumber", storageUnits);

            return View(viewModel);
        }

        // POST: Contracts/AddStorage/5 Add storage units to contract.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStorage(ContractBuilderViewModel viewModel)
        {
            viewModel.SelectedStorageUnit = db.StorageUnits.Find(viewModel.SelectedStorageUnitId);
            //assign storage unit to this contract.
            viewModel.SelectedStorageUnit.ContractId = viewModel.Contract.Id;

            Contract contract = db.Contracts.Find(viewModel.Contract.Id);
            viewModel.Contract = contract;

            viewModel.Contract.ContractTotal = 1000M;//hard coded to test.
                //sum of all storage unit rates where storage unit is associated with this contract.
                
                //db.StorageUnits.Rate;

            //Update contract total
            //contract.Total = sum of all storage unit rates where storageunit.ContractId == Contract.Id 





            // What do I need to do to make the model valid?
            //if (ModelState.IsValid)
            //{
                //db.Entry(viewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddStorage", "Contracts", new { id = viewModel.Contract.Id });//go where?
            //}
            //Where to go if it fails to update?
            //return RedirectToAction("AddStorage", "Contracts", new { id = viewModel.Contract.Id });
                                                          // or View(viewModel);
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
