using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specification;
using BinaryDataRepositoryLIb;
using POCO;
using System.Net;
namespace Services
{
    public class AuthService : IAuthService
    {
        public bool Seeding()
        {
            bool status = false;
            List<Credenail> credentialList = new List<Credenail>();
            credentialList.Add(new Credenail { Email = "abcd@gmail.com", Password = "123456" });
            credentialList.Add(new Credenail { Email = "PQRS@gmail.com", Password = "456789" });
            List<User> userList = new List<User>();
            userList.Add(new User { Id = 1, FirstName = "Shri", LastName = "Patil", Email = "abcd@gmail.com", ContactNo = "9527595801" });
            userList.Add(new User { Id = 2, FirstName = "Raju", LastName = "Jadhv", Email = "pqrs@gmail.com", ContactNo = "9527595802" });
            IDataRepository<Credenail> credentialRepository = new BinaryRepository<Credenail>();
            IDataRepository<User> userRepository = new BinaryRepository<User>();
            status = credentialRepository.Serialize("Credlist.dat", credentialList);
            status = userRepository.Serialize("Userslist.dat", userList);
            return status;

        }
        public bool ForgotPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
        public List<Credenail> GetAllCredentials()
        {
            List<Credenail> credentials = new List<Credenail>();
            IDataRepository<Credenail> repository = new BinaryRepository<Credenail>();
            credentials = repository.Deserialize("Credlist.dat");
            return credentials;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            IDataRepository<User> repository = new BinaryRepository<User>();
            users = repository.Deserialize("Userslist.dat");
            return users;
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User u, string pwd)
        {
            bool status = false;
            List<User> users = new List<User>();
            users = GetAllUsers();
            users.Add(u);
            List<Credenail> credentials = new List<Credenail>();
            credentials = GetAllCredentials();
            Credenail credential = new Credenail { Email = u.Email, Password = pwd };
            credentials.Add(credential);

            IDataRepository<User> repository = new BinaryRepository<User>();
            status = repository.Serialize("Userslist.dat", users);

            IDataRepository<Credenail> dataRepository = new BinaryRepository<Credenail>();
            status = dataRepository.Serialize("Credlist.dat", credentials);
            return status;
            // throw new NotImplementedException();
        }

        public bool ResetPassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}