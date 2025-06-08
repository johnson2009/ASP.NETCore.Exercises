
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var claims = new List<Claim>();
claims.Add(new Claim(ClaimTypes.NameIdentifier, "6"));
claims.Add(new Claim(ClaimTypes.Name, "Ethan"));
claims.Add(new Claim(ClaimTypes.Role, "admin"));
claims.Add(new Claim(ClaimTypes.Role, "role2"));
claims.Add(new Claim("Passport", "123456"));

string key = "dfaklfjdalfjdaslfjaytututututugjhgdsfdsfdajs";
DateTime expires = DateTime.Now.AddMinutes(30);

byte[] secBytes = Encoding.UTF8.GetBytes(key);
var secKey = new SymmetricSecurityKey(secBytes);
var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
var tokenDescripttor = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);
var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescripttor);

Console.WriteLine("====================================");
Console.WriteLine(jwt);
Console.WriteLine("====================================");
