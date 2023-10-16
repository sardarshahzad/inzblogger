using blogger.Data;
using blogger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository.Implementation
{
    public class UserRepository : IUser
    {
         
        private readonly inzBloggerContext _db;

        public UserRepository(inzBloggerContext db)
        {
            _db = db;
        }
        //-----User
        public List<User> GetUsers()
        {
            return _db.Users.Include(x => x.UserRole).ToList();
        }
        public User GetUser(int id)
        {
            return _db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        //-----User Role
        public List<UserRole> GetRoles()
        {
            return _db.UserRoles.ToList();
        }
        public UserRole GetRole(int id)
        {
            return _db.UserRoles.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddUpdateRole(UserRole userRole)
        {
            _db.UserRoles.Update(userRole);
            _db.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            UserRole userRole = _db.UserRoles.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _db.Remove(userRole);
            _db.SaveChanges();

        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
 