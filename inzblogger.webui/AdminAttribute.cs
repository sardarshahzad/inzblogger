using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using blogger.Data;

namespace inzblogger.webui
{
    public class AdminAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string accessToken = context.HttpContext.Request.Cookies["user-access-token"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                inzBloggerContext db = context.HttpContext.RequestServices.GetRequiredService<inzBloggerContext>();
                var test = db.Users.Where(x => x.AccessToken.Equals(accessToken) && x.UserRole.Name.Equals("Admin")).Any();

                if (!test)
                {
                    context.Result = new RedirectResult("/Account/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }



        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }


    }
}
