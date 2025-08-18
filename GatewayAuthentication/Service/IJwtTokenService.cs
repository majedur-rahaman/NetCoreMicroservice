using GatewayAuthentication.Models;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace GatewayAuthentication.Service
{
    public interface IJwtTokenService
    {
        AuthToken GenerateAuthToken(LoginUser user);
    }
}
