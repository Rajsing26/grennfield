using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDFCBankApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            string theMessage = "Hello i am Manager,welcom to team ";
            TempData["mymsg"] = theMessage;
            //return View();
            return RedirectToAction("Thankyou");   

        }
        public ActionResult Process() 
        {
            String theMessage = TempData["mymsg"] as string;
            ViewData["processmsg"] = theMessage;
            return View();  
        }
        public ActionResult Thankyou()
        {
            String theMessage = TempData["mymsg"] as string;
            ViewData["processmsg"] = theMessage;
            return View();
        }

    }
}