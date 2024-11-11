using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Membership;
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


            if(svc.Login("Raj@gmail.com","1234"))
            {
                Console.WriteLine("Correct Pass and Email");
            }
            else
            {
                Console.WriteLine("Wrong Cred");
            }
            Console.ReadLine();
        }
    }
}
