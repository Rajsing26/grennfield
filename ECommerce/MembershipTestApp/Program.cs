using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using Services;
using Specification;

namespace MembershipTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

           AuthService svc = new AuthService();
            svc.Seeding();


            /*if(svc.Login("Raj@gmail.com","1234"))
            {
                Console.WriteLine("Correct Pass and Email");
            }
            else
            {
                Console.WriteLine("Wrong Credential");
            }*/

           // AuthService svc = new AuthService();

            string pass = "xyz";
            User u = new User { Id = 1, FirstName = "Rajsing", LastName = "Jadhav", Email = "Rajsing@gmail.com", ContactNo = "9860838138" };
            Console.WriteLine(svc.Register(u, pass));
            List<User> allUsers = svc.GetAllUsers();
            foreach (User user in allUsers)
            {
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
            }

            List<Credenail> allCredentials = svc.GetAllCredentials();
            foreach (Credenail cred in allCredentials)
            {
                Console.WriteLine(cred.Email + " " + cred.Password);
            }
            Console.ReadLine();

        }
    }
}
