using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinedOn { get; set; }
        public string AccessToken { get; set; }
        public bool IsConfirmed { get; set; }
        public UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
