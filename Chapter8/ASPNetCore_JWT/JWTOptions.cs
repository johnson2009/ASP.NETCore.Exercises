namespace ASPNetCore_JWT;

public class JWTOptions
{
    public string SigningKey { get; set; } = string.Empty;
    public int ExpireSeconds { get; set; } = 3600;
}
