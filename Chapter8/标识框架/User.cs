using Microsoft.AspNetCore.Identity;

namespace 标识框架;

public class User: IdentityUser<long>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public String? NickName { get; set; }
}
