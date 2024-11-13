using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingPortal.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Index(string email,string password)
        {
            if(email == "Rajisng@gmail.com" && password == "1234") 
            {
                return RedirectToAction("Welcome");   
            }
            else
            {
                return View();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
    }
}