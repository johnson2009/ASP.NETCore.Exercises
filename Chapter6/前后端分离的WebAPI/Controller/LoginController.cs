using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace 前后端分离的WebAPI.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController: ControllerBase
{
    [HttpPost]
    public ActionResult<LoginResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest.UserName == "admin" && loginRequest.Password == "123456")
        {
            var processes = Process.GetProcesses()
                .Select(p => new ProcessInfo(p.Id, p.ProcessName, p.WorkingSet64))
                .ToArray();
            return Ok(new LoginResult(true, processes));
        }
        else
        {
            return Ok(new LoginResult(false, null));
        }
    }
}
