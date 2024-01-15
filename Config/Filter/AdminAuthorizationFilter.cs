using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWT.Practice.NET.Config.Filter
{
    public class AdminAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsInRole("Administrator"))
                context.Result = new UnauthorizedObjectResult(new JsonResult(new { message = "No role admin" }));
        }
    }
}