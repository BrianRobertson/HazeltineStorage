using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HazeltineStorage.Controllers
{
    public class HazeltineManagerController : Controller
    {
        // GET: HazeltineManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: HazeltineManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HazeltineManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HazeltineManager/Create
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

        // GET: HazeltineManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HazeltineManager/Edit/5
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

        // GET: HazeltineManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HazeltineManager/Delete/5
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
