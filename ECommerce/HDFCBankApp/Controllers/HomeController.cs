using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            Contact cnt = new Contact
            {
                ContactNumber = "1234567899",
                Email = "Simplify",
                website = "Simplif.com"
        };
            ViewData["Contact"] = cnt;

            return View();
        }
    }
}