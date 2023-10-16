using blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository
{
    public interface IUserAccount
    {
        string Register(User user);

        User GetUserForLogin(string email, string password);
        User GetUserInfo(string accessToken);
    }
}
