using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceServices;
using Specification;
using EcommerceEntities;
using System.Net;
namespace MembershipTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AuthService svc = new AuthService();
            svc.Seeding();
            bool f = true;
            while (f)
            {
                Console.WriteLine("Menu \n 1. Register \n 2. Login \n 3. Forgot Password \n 4. Reset Password \n 5. Print All \n 5. Exit");
                Console.WriteLine("Enter your Choice(1-4) : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string FName, LName, Mail, Contact;
                        Console.WriteLine("Enter First Name: ");
                        FName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name: ");
                        LName = Console.ReadLine();
                        Console.WriteLine("Enter Email: ");
                        Mail = Console.ReadLine();
                        Console.WriteLine("Enter Contact no: ");
                        Contact = Console.ReadLine();
                        string Password;
                        Console.WriteLine("Enter Password: ");
                        Password = Console.ReadLine();
                        User u = new User { FirstName = FName, LastName = LName, Email = Mail, ContactNo = Contact };
                        if (svc.Register(u, Password))
                        {
                            Console.WriteLine("Registration Successful");
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessful");
                        }
                        break;
                    case 2:
                        string email;
                        Console.WriteLine("\n Please enter email address");
                        email = Console.ReadLine();
                        string password;
                        Console.WriteLine("\n Please enter password");
                        password = Console.ReadLine();
                        bool flag = svc.Login(email, password);
                        if (flag == true)
                        {
                            Console.WriteLine("LOGIN SUCCESSFUL");
                        }
                        else
                        {
                            Console.WriteLine("LOGIN UNSUCCESSFUL");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Email address: ");
                        email = Console.ReadLine();

                        Console.WriteLine("Your Old Password is: " + svc.ForgotPassword(email));
                        break;
                    case 4:
                        Console.WriteLine("Enter Email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Enter old password: ");
                        password = Console.ReadLine();
                        Console.WriteLine("Enter new password: ");
                        string newpass = Console.ReadLine();
                        if (svc.ResetPassword(email, password, newpass))
                        {
                            Console.WriteLine("Password Reset Successful");
                        }
                        else
                        {
                            Console.WriteLine("Password Reset Unsuccessful");
                        }
                        break;
                    case 5:
                        List<User> allUsers = svc.GetAllUser();
                        foreach (User user in allUsers)
                        {
                            Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
                        }

                        List<Credenail> allCredentials = svc.GetAllCredentials();
                        foreach (Credenail cred in allCredentials)
                        {
                            Console.WriteLine(cred.Email + " " + cred.Password);
                        }
                        break;
                    case 6:
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;

                }
            }







            Console.ReadLine();
        }
    }
}