using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace 异常筛选器;

public class MyExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<MyExceptionFilter> logger;
    private readonly IHostEnvironment env;
    public MyExceptionFilter(ILogger<MyExceptionFilter> logger, IHostEnvironment env)
    {
        this.logger = logger;
        this.env = env;
    }
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        logger.LogError(context.Exception, "发生异常");
        logger.LogError(context.Exception, "发生异常：{Message}", context.Exception.Message);
        logger.LogError("发生异常：{Message}", context.Exception.Message);

        string message;
        if (env.IsDevelopment())
        {
            //await context.HttpContext.Response.WriteAsync(context.Exception.ToString());
            message = context.Exception.ToString();
        }
        else
        {
            //await context.HttpContext.Response.WriteAsync("发生异常");
            message = "程序中发生异常";
        }

        ObjectResult result = new ObjectResult(new
        {
            code = 500,
            message = message,
            detail = context.Exception.Message
        })
        {
            StatusCode = 500
        };
        context.Result = result;
        context.ExceptionHandled = true;
        await Task.CompletedTask;
    }
}
