using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace 标识框架.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Test1Controller : ControllerBase
{
    private readonly ILogger<Test1Controller> _logger;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public Test1Controller(ILogger<Test1Controller> logger, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUserRole()
    {
        bool roleExists = await _roleManager.RoleExistsAsync("admin");
        if (!roleExists)
        {
            Role role = new Role { Name = "admin", NormalizedName = "admin".ToUpper() };
            var r = await _roleManager.CreateAsync(role);
            if (!r.Succeeded)
            {
                return BadRequest(r.Errors);
            }
        }

        User user = await _userManager.FindByNameAsync("ziqiasun");
        if (user == null)
        {
            user = new User
            {
                UserName = "ziqiasun",
                NormalizedUserName = "ziqiasun".ToUpper(),
                NickName = "ziqiasun",
                Email = "ziqiasun@amd.com",
                EmailConfirmed = true
            };

            var r = await _userManager.CreateAsync(user, "123456");
            if (!r.Succeeded)
            {
                return BadRequest(r.Errors);
            }
            r = await _userManager.AddToRoleAsync(user, "admin");
            if (!r.Succeeded)
            {
                return BadRequest(r.Errors);
            }
        }
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginRequest req)
    {
        string userName = req.UserName;
        string password = req.Password;
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return NotFound($"用户名不存在{userName}");
        }
        if (await _userManager.IsLockedOutAsync(user))
        {
            return BadRequest("用户被锁定");
        }
        var success = await _userManager.CheckPasswordAsync(user, password);
        if (success)
        {
            return Ok("登录成功");
        }
        else
        {
            await _userManager.AccessFailedAsync(user);
            var count = await _userManager.GetAccessFailedCountAsync(user);
            if (count >= 5)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(5));
            }
            return BadRequest("密码错误");
        }
    }

    [HttpPost]
    public async Task<ActionResult> SendResetPasswordToken(SendResetPasswordTokenRequest req)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        if (user == null)
        {
            return NotFound($"用户不存在{req.Email}");
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        _logger.LogInformation("重置密码的token: {token}", token);
        return Ok(token);
    }

    [HttpPost]
    public async Task<ActionResult> VeriryResetPasswordToken(VerifyResetPasswordToken req)
    {
        string email = req.Email;
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound($"用户不存在{email}");
        }

        string token = req.Token;
        string newPassword = req.NewPassword;
        string newPassword2 = req.NewPassword2;
        if(newPassword != newPassword2)
        {
            return BadRequest("两次密码不一致");
        }
        
        var r = await _userManager.ResetPasswordAsync(user, token, newPassword);
        if (r.Succeeded)
        {
            return Ok("重置密码成功");
        }
        else
        {
            return BadRequest(r.Errors);
        }
    }
}
