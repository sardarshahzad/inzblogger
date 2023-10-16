using blogger.Models;
using blogger.Repository;
using Microsoft.AspNetCore.Mvc;

namespace inzblogger.webui.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccount _userAccount;
        public AccountController(IUserAccount userAccount) 
        {
            _userAccount = userAccount;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection data) 
        {
            string email = data["EmailAdress"];
            string password = data["password"];
            var dbuser = _userAccount.GetUserForLogin(email, password);
            if (dbuser == null) 
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.UtcNow.AddDays(30);
                Response.Cookies.Append("user-ascess-token",dbuser.AccessToken, option);
                return Redirect("/Home/Index");
            }
            ViewBag.Error = "Enter a Correct Password";
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            string confirmationToken = _userAccount.Register(user);
            if (string.IsNullOrEmpty(confirmationToken))
            {
                ViewBag.error = "please Enter Correct Information";
                return View();
            }
            else
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.UtcNow.AddDays(30);
                Response.Cookies.Append("user-access-token", user.AccessToken, options);
                return Redirect("/Home/Index");
            }
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user-access-token");
            return Redirect("/Home/Index");
        }
    }
}
