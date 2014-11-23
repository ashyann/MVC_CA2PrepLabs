using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureStorageCalc.Models;

namespace AzureStorageCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(StorageAccount sa)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Price", sa);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Price(StorageAccount sa)
        {
            return View(sa);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}