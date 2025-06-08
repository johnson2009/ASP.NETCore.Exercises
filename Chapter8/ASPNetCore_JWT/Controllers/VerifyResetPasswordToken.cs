namespace ASPNetCore_JWT.Controllers;

public record VerifyResetPasswordToken(String Email, string Token, string NewPassword, string NewPassword2);