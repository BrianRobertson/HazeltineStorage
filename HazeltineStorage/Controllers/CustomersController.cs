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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CustomerStatus).Include(c => c.CustomerType).Include(c => c.User);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult DetailsReadOnly(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }



        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription");
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CustomerTypeId,CustomerStatusId,FirstName,LastName,Address1,Address2,City,State,Zip,MainPhone,MobilePhone,TextNotification,EmailAddress,EmailNotification,EmailInvoice,CustomerBalance,CustomerNote")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        //Brian added below code:

        // GET: Customers/Inquiry
        public ActionResult Inquire()
        {
            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription");
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Customers/NewInquiry
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inquire([Bind(Include = "Id,UserId,CustomerTypeId,CustomerStatusId,FirstName,LastName,Address1,Address2,City,State,Zip,MainPhone,MobilePhone,TextNotification,EmailAddress,EmailNotification,EmailInvoice,CustomerBalance,CustomerNote")] Customer customer)
        //public ActionResult Inquire([Bind(Include = "FirstName,LastName,MainPhone,MobilePhone,TextNotification,EmailAddress,EmailNotification,CustomerNote")] Customer customer)
        // I tried only listed items. It didn't work.
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");// redirect to thank you page.
            }

            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        //Brian added above code.

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CustomerTypeId,CustomerStatusId,FirstName,LastName,Address1,Address2,City,State,Zip,MainPhone,MobilePhone,TextNotification,EmailAddress,EmailNotification,EmailInvoice,CustomerBalance,CustomerNote")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        //Brian code below:
        // GET: Customers/Manage/
        public ActionResult Manage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        //Not used at the moment:
        //public ActionResult _SubmissionTab()
        //{
        //    return PartialView();
        //}

        //public ActionResult _SearchTab()
        //{
        //    return PartialView();
        //}



        //Brian code above.

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
