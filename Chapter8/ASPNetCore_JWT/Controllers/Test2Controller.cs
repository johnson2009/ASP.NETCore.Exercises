using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore_JWT.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public class Test2Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Hello()
    {
        string id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        string userName = User.FindFirst(ClaimTypes.Name)!.Value;
        IEnumerable<Claim> roleClaims = User.FindAll(ClaimTypes.Role);
        string roles = string.Join(",", roleClaims.Select(c => c.Value));

        
        
        return Ok($"Id={id}, UserName={userName}, Roles={roles}");
    }

}
