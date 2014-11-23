using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureCloudServices.Models;

namespace AzureCloudServices.Controllers
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
        public ActionResult Calculate(AzureCloudService acs)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirmation", acs);
            }
            else
            {
                return View(acs);
            }
        }
        public ActionResult Confirmation(AzureCloudService azure)
        {
            return View(azure);
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