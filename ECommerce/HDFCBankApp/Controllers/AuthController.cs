using HDFCBankApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace HDFCBankApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            IAuthService svc = new AuthService();
            if (svc.Login(email, password))
            {
                this.HttpContext.Session["loggedinUser"] = email;
                return RedirectToAction("Welcome");   
            }
            else
            {

                return View();
            }
           
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string contactnumber,string email,string location)
        {

            //this.HttpContext.Session["loggedinUser"] = email;
            IAuthService svc = new AuthService();
            User u = new User { FirstName = firstname, LastName = lastname, Email = email, ContactNo = contactnumber, Location =location };
            if (svc.Register(u, "password"))
            {

                return RedirectToAction("Welcome");
            }
            else
            {

                return View();
            }
            
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            string email = this.HttpContext.Session["loggedinUser"] as string;
            ViewBag.Email = email;
            return View();
        }
    }
}