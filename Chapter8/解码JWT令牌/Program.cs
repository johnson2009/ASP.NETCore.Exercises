
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Input JWT token to decode:");
string jwt = Console.ReadLine()!;
string secKey = "dfaklfjdalfjdaslfjaytututututugjhgdsfdsfdajs";

JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
TokenValidationParameters valParam = new();
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secKey));
valParam.IssuerSigningKey = securityKey;
valParam.ValidateIssuer = false;
valParam.ValidateAudience = false;
ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwt, valParam, out SecurityToken validatedToken);

foreach (var claim in claimsPrincipal.Claims)
{
    Console.WriteLine($"{claim.Type}: {claim.Value}");
}



// using System.Text;

// string jwt = Console.ReadLine()!;
// string[] segments = jwt.Split('.');
// string header = segments[0];
// string payload = segments[1];

// Console.WriteLine("================head====================");
// Console.WriteLine(JwtDecode(header));
// Console.WriteLine("==================payload==================");
// Console.WriteLine(JwtDecode(payload));


// string JwtDecode(string jwt)
// {
//     jwt = jwt.Replace('-', '+').Replace('_', '/');
//     switch (jwt.Length % 4)
//     {
//         case 2:
//             jwt += "==";
//             break;
//         case 3:
//             jwt += "=";
//             break;
//     }
//     var bytes = Convert.FromBase64String(jwt);
//     return Encoding.UTF8.GetString(bytes);
// }