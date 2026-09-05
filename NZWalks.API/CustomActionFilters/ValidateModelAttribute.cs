using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalks.API.CustomActionFilters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    override public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!filterContext.ModelState.IsValid)
        {
            filterContext.Result = new BadRequestResult();
        }
    }
}