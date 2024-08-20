using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.BookShelf.Aplication.Filters
{
    public class CustomAuthorizationFilter: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is in the "Admin" role
            if (!context.HttpContext.User.IsInRole("Admin"))
            {
                // If not, deny access and return a forbidden status
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

        }




    }
}
