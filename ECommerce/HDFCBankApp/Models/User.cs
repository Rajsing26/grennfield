﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDFCBankApp.Models
{
    public class User
    {

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public string location { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        //public string UserName { get; set; }

        public string Location {  get; set; }   

    }
}