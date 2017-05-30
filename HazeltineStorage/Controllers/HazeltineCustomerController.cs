using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HazeltineStorage.Controllers
{
    public class HazeltineCustomerController : Controller
    {

        // GET: HazeltineCustomer
        public ActionResult Index()
        {
            return View();
        }

        // GET: HazeltineCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HazeltineCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HazeltineCustomer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HazeltineCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HazeltineCustomer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HazeltineCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HazeltineCustomer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
