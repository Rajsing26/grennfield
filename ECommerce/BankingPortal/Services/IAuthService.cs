﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BankingPortal.Models;



namespace BankingPortal.Models
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(User user, string password);
         bool Seeding();

        string ForgotPassword(string username);

        bool ResetPassword(string username, string oldpassword, string newpassword);

        List<User> GetAllUser();
        List<Credenail> GetAllCredentials();

        User GetById(int id);
        bool Delete(int id);
    }
}