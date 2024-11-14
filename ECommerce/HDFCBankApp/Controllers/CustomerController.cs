using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> list = new List<Customer>();

        public CustomerController() 
        {
            list.Add(new Customer { Id = 1, Name = "Rajsing", Email = "Rajsing@gmail.com", Location = "Malegaon" });
            list.Add(new Customer { Id = 2, Name = "Shri", Email = "Shri@gmail.com", Location = "Solapur" });
            list.Add(new Customer { Id = 3, Name = "Vishal", Email = "Vishal@gmail.com", Location = "Pune" });
        }

        // GET: Customer
        public ActionResult Index()
        {
            ViewData["list"] =list; 
            return View();
        }

        public ActionResult Details(int id)
        {
            Customer customer = list.Find(cust=> cust.Id == id); 
            return View(customer);
        }
    }
}