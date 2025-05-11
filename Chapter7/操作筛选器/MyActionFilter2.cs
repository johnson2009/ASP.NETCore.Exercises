using Microsoft.AspNetCore.Mvc.Filters;

namespace 操作筛选器
{
    public class MyActionFilter2: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("MyActionFilter2: Before action execution.");
            Console.WriteLine(context.HttpContext.Request.Path);
            ActionExecutedContext r = await next();
            if (r.Exception != null)
            {
                Console.WriteLine("MyActionFilter2: After action execution with exception.");
            }
            else
            {
                Console.WriteLine("MyActionFilter2: After action execution without exception.");
            }
        }
    }
}
