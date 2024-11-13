using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
//using BinaryDataRepositoryLib;
using BinaryDataRepositoryLIb;
using JsonDataRepositoryLib;
using EcommerceEntities;
using Specification;

namespace EcommerceServices
{

    public class AuthService : IAuthService
    {
        public static string logfile = @"E:/log.json";

        public static string credfile = @"E:/credentials.json";

        public bool Seeding()
        {

            bool status = false;
            List<User> Users = new List<User>();
            List<Credenail> credentials = new List<Credenail>();
            Users.Add(new User { FirstName = "Rajsing", LastName = "Jadhav", Email = "Rajsing@gmail.com", ContactNo = "9860838138" });
            Users.Add(new User { FirstName = "shri", LastName = "Patil", Email = "shri@gmail.com", ContactNo = "1234567891" });
           
            credentials.Add(new Credenail { Email = "ram@gmail.com", Password = "1234" });
            credentials.Add(new Credenail { Email = "sham@gmail.com", Password = "0000" });
            
            IDataRepository<User> repository = new JsonRepository<User>();
            IDataRepository<Credenail> dataRepository = new JsonRepository<Credenail>();
            status = repository.Serialize(logfile, Users);
            status = false;
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }
        public bool Register(User u, string pass)
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUser();
            users.Add(u);

            List<Credenail> credentials = new List<Credenail>();
            credentials = GetAllCredentials();
            Credenail credential = new Credenail { Email = u.Email, Password = pass };
            credentials.Add(credential);

            IDataRepository<User> repository = new JsonRepository<User>();
            status = repository.Serialize(logfile, users);

            status = false;

            IDataRepository<Credenail> dataRepository = new JsonRepository<Credenail>();
            status = dataRepository.Serialize(credfile, credentials);
            return status;
        }

        public string ForgotPassword(string username)
        {
            List<Credenail> credentials = new List<Credenail>();
            credentials = GetAllCredentials();
            foreach (Credenail cred in credentials)
            {
                if (cred.Email == username)
                {
                    return cred.Password;
                }
            }
            return null;

        }
        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            IDataRepository<User> repository = new JsonRepository<User>();
            users = repository.Deserialize(logfile);
            return users;
        }
        public List<Credenail> GetAllCredentials()
        {
            List<Credenail> credentials = new List<Credenail>();
            IDataRepository<Credenail> repository = new JsonRepository<Credenail>();
            credentials = repository.Deserialize(credfile);
            return credentials;
        }


        public bool Login(string username, string password)
        {
            IDataRepository<Credenail> repository = new JsonRepository<Credenail>();
            List<Credenail> credentials = repository.Deserialize(credfile);
            foreach (Credenail cred in credentials)
            {
                if (cred.Email == username && cred.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ResetPassword(string username, string oldpassword, string newpassword)
        {
            List<Credenail> credentials = new List<Credenail>();
            credentials = GetAllCredentials();
            foreach (Credenail cred in credentials)
            {
                if (cred.Email == username & cred.Password == oldpassword)
                {
                    cred.Password = newpassword;
                    IDataRepository<Credenail> dataRepository = new JsonRepository<Credenail>();
                    return dataRepository.Serialize(credfile, credentials);
                }
            }
            return false;
        }


        public User GetById(int id)
        {
            //foreach (Product product in products)
            //{
            //    if (product.Id == id)
            //    {
            //        return product;
            //    }

            //}
            //return null;
            //return new Product { Id = 1, Title = "Gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 5000, ImageUrl = "/Images/Gerbera.jfif" };
            User user = null;
            List<User> users = GetAllUser();
            foreach (User u in users)
            {
                if (u.Id == id)
                {
                    user = u;
                }
            }
            return user;
        }

        public bool Delete(int id)
        {
            User user = GetById(id);
            if (user != null)
            {
                List<User> users = GetAllUser();
                users.RemoveAll(u => u.Id == id);
                IDataRepository<User> repository = new JsonRepository<User>();
                repository.Serialize(@"D:\Users.json", users);
                return true;
            }
            return false;
        }
    }
}