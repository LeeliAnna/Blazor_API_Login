using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blazor_API_Login.Tools
{
    public class TokenManager
    {
        public static string key = "azertyuiopqsdfghjklmwxcvbn";

        public string GenerateToken(User u)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myClaims = new[]
            {
                new Claim(ClaimTypes.Name, u.Pseudo),
                new Claim(ClaimTypes.Role, u.Pseudo == "Spirou" ? "admin" : "user"),
                new Claim("id", u.Id.ToString()),
            };

            JwtSecurityToken jwt = new JwtSecurityToken(claims: myClaims, signingCredentials: credentials, expires: DateTime.Now.AddDays(1));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwt);
        }
    }
}
