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
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Customer).Include(p => p.PaymentType);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Details/5 Read Only
        public ActionResult DetailsReadOnly(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }




        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName");
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId");
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,ReceivedDate,PaymentTypeId,AmountReceived,Notes,DepositDate")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();

                //UpdateCustomerBalance helper method:
                UpdateCustomerBalance(payment.CustomerId);

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", payment.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", payment.CustomerId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName", payment.PaymentTypeId);
            return View(payment);
        }

        // GET: Payments/Create For This Customer
        public ActionResult CreateForThisCustomer(int thisCustomerId)
        {
            Customer thisCustomer = db.Customers.Find(thisCustomerId);
            Payment payment = new Payment();
            payment.CustomerId = thisCustomerId;
            payment.ReceivedDate = DateTime.Now;
            payment.AmountReceived = thisCustomer.CustomerBalance.GetValueOrDefault();

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName");
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId");
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName");
            return View(payment);
        }



        // GET: Payments/Confirm Online Payment
        public ActionResult ConfirmOnlinePayment(int? id)
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

            Payment payment = new Payment();
            payment.CustomerId = customer.Id;
            payment.ReceivedDate = DateTime.Now;
            payment.PaymentTypeId = 2;//Payment via Website.
            payment.AmountReceived = customer.CustomerBalance.GetValueOrDefault();
            payment.Notes = "Make any notes about this payment here.";
            //payment.DepositDate = payment.DepositDate.GetValueOrDefault();

            //Build view model with customer and payment
            var viewModel = new CustomerPaymentViewModel
            {
                Customer = customer,
                Payment = payment
            };

            //ViewBag.CustomerStatusId = new SelectList(db.CustomerStatus, "Id", "StatusDescription", customer.CustomerStatusId);
            //ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "TypeDescription", customer.CustomerTypeId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            //ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName");
            return View(viewModel);
        }


        //Brian added:
        // POST: Payments/ConfirmOnlinePayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOnlinePayment([Bind(Include = "Id,CustomerId,ReceivedDate,PaymentTypeId,AmountReceived,Notes,DepositDate")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();

                //UpdateCustomerBalance helper method:
                UpdateCustomerBalance(payment.CustomerId);

                //Newly created payment is the starting point for creating a Paypal object:
                Payment confirmedOnlinePayment = payment;

                return RedirectToAction("PaymentWithPaypal", "Paypal", confirmedOnlinePayment);

                //return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", payment.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", payment.CustomerId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName", payment.PaymentTypeId);
            return View(payment);
        }

        // POST: Payments/UpdateFailedPayment, for when Paypal doesn't approve transaction.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void UpdateFailedPayment([Bind(Include = "Id,CustomerId,ReceivedDate,PaymentTypeId,AmountReceived,Notes,DepositDate")]Payment revisedOnlinePaymentRecord)
        {
            //if (ModelState.IsValid)
            //{
                db.Entry(revisedOnlinePaymentRecord).State = EntityState.Modified;
                db.SaveChanges();

            //UpdateCustomerBalance helper method:
            UpdateCustomerBalance(revisedOnlinePaymentRecord.CustomerId);

            //return RedirectToAction("Index");
            //}
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", payment.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", payment.CustomerId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName", payment.PaymentTypeId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,ReceivedDate,PaymentTypeId,AmountReceived,Notes,DepositDate")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();

                //UpdateCustomerBalance helper method:
                UpdateCustomerBalance(payment.CustomerId);

                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "LastName", payment.CustomerId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "UserId", payment.CustomerId);
            ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "PaymentTypeName", payment.PaymentTypeId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();

            //UpdateCustomerBalance helper method:
            UpdateCustomerBalance(payment.CustomerId);

            return RedirectToAction("Index");
        }

        //POST: Payments/UpdateCustomerCustomerBalance/Id helper method
        public void UpdateCustomerBalance([Bind(Include = "CustomerBalance")] int id)
        {
            Customer customer = db.Customers.Find(id);
            //The following two lines of code will fail if the customer has null of either invoices or payments.
            decimal? customerInvoicesTotal = db.Invoices.Where(i => i.CustomerId == customer.Id).Sum(i => i.TotalDue);
            decimal? customerPaymentsTotal = db.Payments.Where(p => p.CustomerId == customer.Id).Sum(p => p.AmountReceived);

            decimal? customerNetTotal = (customerInvoicesTotal - customerPaymentsTotal);

            customer.CustomerBalance = customerNetTotal;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
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
