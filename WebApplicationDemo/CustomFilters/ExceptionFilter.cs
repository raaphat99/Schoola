using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationDemo.CustomFilters
{
    public class ExceptionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "Something went wrong. Please try again later." };
            }
            base.OnActionExecuted(context);
        }
    }
}
