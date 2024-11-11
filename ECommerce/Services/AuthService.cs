using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDataRepositoryLIb;
using POCO;
using Specification;

namespace Membership
{
    public class AuthService : IAuthService
    {
        public bool Seeding()
        {
            bool status=false;
            List<Credenail> cred = new List<Credenail>();
            cred.Add(new Credenail { Email="Raj@gmail.com",Password="1234"});
            //cred.Add(new Credenail { Email="Raj@gmail.com",Password="1234"});
            //cred.Add(new Credenail { Email = "Raj@gmail.com", Password = "1234" });

            IDataRepository<Credenail> repo = new BinaryRepository<Credenail>();
            status = repo.Serialize("Credenail.dat", cred);


            return status;  

        }
        public bool ForgotPassword(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            bool foundCredenail = false;
            IDataRepository<Credenail> repo = new BinaryRepository<Credenail>();
            List<Credenail> cred = repo.Deserialize("Credenail.dat");
            foreach (Credenail c in cred)
            {
                if (c.Email == username && c.Password==password)
                {
                    return true;    

                }
            }
            return foundCredenail;
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool RestPassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
