using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Repositories.Filters
{
    public class EnsureExistsFilters : IActionFilter
    {

        public EnsureExistsFilters()
        {            
        }
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int itemId = (int)context.ActionArguments["itemId"];
            //if (!_service.DoesExist(itemId))
            //{
            //    context.Result = new NotFoundResult();
            //}
        }
    }

    public class EnsureExistsAttribute : TypeFilterAttribute
    {
        public EnsureExistsAttribute() : base(typeof(EnsureExistsFilters))
        {
        }
    }
}
