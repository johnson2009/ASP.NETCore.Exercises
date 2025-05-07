using Microsoft.AspNetCore.Mvc;
using MVC项目.Models;

namespace MVC项目.Controllers;
public class TestController : Controller
{
    public IActionResult Demo1()
    {
        var model = new Person("Zack", true, new DateTime(1999,9, 9));
        return View(model);
    }
}
