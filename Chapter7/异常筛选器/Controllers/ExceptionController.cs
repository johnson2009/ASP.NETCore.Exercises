using Microsoft.AspNetCore.Mvc;

namespace 异常筛选器.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExceptionController : ControllerBase
{
    private readonly ILogger<ExceptionController> logger;
    public ExceptionController(ILogger<ExceptionController> logger)
    {
        this.logger = logger;
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        //throw new Exception("测试异常");
        throw new DivideByZeroException("测试异常");
    }
}
