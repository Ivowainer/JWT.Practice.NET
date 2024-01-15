using JWT.Practice.NET.Models;
using JWT.Practice.NET.Models.Dto;

namespace JWT.Practice.NET.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(UserModelDto userModelDto);
        public string GenerateToken(UserModel user);
    }
}