using BankingPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingPortal.Controllers
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
        public ActionResult Register(string username, string oldpassword, string newpassword)
        {
            IAuthService svc = new AuthService();   

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