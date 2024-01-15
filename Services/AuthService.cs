using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.Practice.NET.Constants;
using JWT.Practice.NET.Models;
using JWT.Practice.NET.Models.Dto;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Practice.NET.Services
{
    public class AuthService(IConfiguration config) : IAuthService
    {

        public UserModel Authenticate(UserModelDto userModelDto)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(u => u.Username.ToLower() == userModelDto.Username.ToLower() && u.Password == userModelDto.Password);

            if (currentUser == null)
                return null;


            return currentUser;
        }

        public string GenerateToken(UserModel user)
        {
            var key = Encoding.UTF8.GetBytes(config["JwtConfig:Key"]);
            var securityKey = new SymmetricSecurityKey(key);

            // Arguments: Key, Algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create Claims
            var claims = new[]
            {
                /* new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role), */
                new Claim("username", user.Username),
                new Claim("email", user.EmailAddress),
                new Claim("firstname", user.FirstName),
                new Claim("lastname", user.LastName),
                new Claim("role", user.Role),
            };

            // Create Token
            var token = new JwtSecurityToken(
                config["JwtConfig:Issuer"],
                config["JwtConfig:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}