namespace 标识框架.Controllers;

public record VerifyResetPasswordToken(String Email, string Token, string NewPassword, string NewPassword2);