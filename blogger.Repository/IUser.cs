using blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository
{
    public interface IUser
    {

        //-------UserRole
        List<UserRole> GetRoles();
        UserRole GetRole(int id);
        void AddUpdateRole(UserRole userRole);
        void DeleteRole(int id);
        //-------User
        List<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void AddUpdateUser(User user);
    }
}
