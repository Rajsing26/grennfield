using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
//using BinaryDataRepositoryLib;
using BinaryDataRepositoryLIb;
using POCO;
using Specification;

namespace Services
{

    public class AuthService : IAuthService
    {
        public static string logfile = "logfile.dat";

        public static string credfile = "credentials.dat";

        public bool Seeding()
        {

            bool status = false;
            List<User> Users = new List<User>();
            List<Credenail> credentials = new List<Credenail>();
            Users.Add(new User { FirstName = "Rajsing", LastName = "Jadhav", Email = "Rajsing@gmail.com", ContactNo = "9860838138" });
            Users.Add(new User { FirstName = "shri", LastName = "Patil", Email = "shri@gmail.com", ContactNo = "1234567891" });
           
            credentials.Add(new Credenail { Email = "ram@gmail.com", Password = "1234" });
            credentials.Add(new Credenail { Email = "sham@gmail.com", Password = "0000" });
            
            IDataRepository<User> repository = new BinaryRepository<User>();
            IDataRepository<Credenail> dataRepository = new BinaryRepository<Credenail>();
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

            IDataRepository<User> repository = new BinaryRepository<User>();
            status = repository.Serialize(logfile, users);

            status = false;

            IDataRepository<Credenail> dataRepository = new BinaryRepository<Credenail>();
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
            IDataRepository<User> repository = new BinaryRepository<User>();
            users = repository.Deserialize(logfile);
            return users;
        }
        public List<Credenail> GetAllCredentials()
        {
            List<Credenail> credentials = new List<Credenail>();
            IDataRepository<Credenail> repository = new BinaryRepository<Credenail>();
            credentials = repository.Deserialize(credfile);
            return credentials;
        }


        public bool Login(string username, string password)
        {
            IDataRepository<Credenail> repository = new BinaryRepository<Credenail>();
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
                    IDataRepository<Credenail> dataRepository = new BinaryRepository<Credenail>();
                    return dataRepository.Serialize(credfile, credentials);
                }
            }
            return false;
        }
    }
}