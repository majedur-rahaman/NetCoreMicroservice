using GatewayAuthentication.Models;
using JWTConfiguration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GatewayAuthentication.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IEnumerable<User> users = new List<User>
        {
            new User{Id=1,Name="Kamal",UserName="Kamal02",Email="kamal@gmail.com",Password="123@@",Role="Administrator",Scopes=["write"] },
            new User{Id=2,Name="Jamal",UserName="Jamal09",Email="jamal@gmail.com",Password="123@@", Role="User", Scopes=["read"]}
        };
        public AuthToken GenerateAuthToken(LoginUser loginUser)
        {
            var user = users.Where(u => (u.Email == loginUser.Email || u.UserName == loginUser.UserName) && u.Password == loginUser.Password).FirstOrDefault();
            if (user is null)
                return new AuthToken (string.Empty, 0);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddHours(5);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("Role", user.Role),
                new Claim("scope",string.Join(" ", user.Scopes)),
            };

            var tokenOptions = new JwtSecurityToken
            (
                issuer: JWTExtensions.ValidIssuer,
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new AuthToken(tokenString, expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds );
        }
    }
}
