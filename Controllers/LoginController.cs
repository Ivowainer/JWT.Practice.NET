using JWT.Practice.NET.Constants;
using JWT.Practice.NET.Models;
using JWT.Practice.NET.Models.Dto;
using JWT.Practice.NET.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Practice.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IAuthService authService) : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserModelDto userModelDto)
        {
            var user = authService.Authenticate(userModelDto);

            if (user == null)
                return NotFound("User not found");

            // Create Token
            var token = authService.GenerateToken(user);

            return Ok(token);
        }
    }
}