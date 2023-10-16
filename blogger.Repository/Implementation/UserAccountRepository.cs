using blogger.Data;
using blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository.Implementation
{
    public class UserAccountRepository : IUserAccount
    {
        private readonly inzBloggerContext _db;
        public UserAccountRepository(inzBloggerContext db)
        {
            _db = db;
        }
        public User GetUserForLogin(string email, string password)
        {
            return _db.Users.Where(x=> x.EmailAdress.ToLower().Equals(email.ToLower()) && x.Password.Equals(password)).FirstOrDefault();
        }

        public User GetUserInfo(string accessToken)
        {
            return _db.Users.Where(x => x.AccessToken.Equals(accessToken)).FirstOrDefault();
        }

        public string Register(User user)
        {
            user.UserRoleId = 4;
            user.IsConfirmed = false;
            user.JoinedOn = DateTime.UtcNow.AddHours(5);
            user.AccessToken = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks;
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.AccessToken+ user.JoinedOn.Ticks.ToString();
        }
    }
}
