using GatewayAuthentication.Models;
using GatewayAuthentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GatewayAuthentication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginUser loginUser)
        {
            var loginResult = _jwtTokenService.GenerateAuthToken(loginUser);

            return string.IsNullOrEmpty(loginResult.AccessToken) ? Unauthorized() : Ok(loginResult);

        }
    }
}
