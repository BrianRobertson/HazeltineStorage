using HazeltineStorage.Models;
using HazeltineStorage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HazeltineStorage.Controllers
{
    public class ContractBuilderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContractBuilder
        public ActionResult Index()
        {
            
            return View();
        }

        //GET BuildContract
        //public ActionResult BuildContract()
        //{
        //    var viewModel = new ContractBuilderViewModel();

        //    return View(viewModel);
        //}

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