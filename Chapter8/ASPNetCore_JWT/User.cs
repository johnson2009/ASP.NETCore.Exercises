using Microsoft.AspNetCore.Identity;

namespace ASPNetCore_JWT;

public class User:IdentityUser<long>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public String? NickName { get; set; }
}
