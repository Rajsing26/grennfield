using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;

namespace Specification
{
    public  interface IAuthService
    {

        bool Login(string username, string password);
        bool Register(User user,string password);
        bool ForgotPassword(string username, string password);
        bool ResetPassword(string username, string oldPassword, string newPassword);

        List<User> GetAllUsers();  
        List<Credenail> GetAllCredentials();    
    }
}
