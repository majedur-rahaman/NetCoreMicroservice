namespace GatewayAuthentication.Models
{
    public class AuthToken
    {
        public AuthToken(string accessToken, double expiredIn)
        {
            AccessToken = accessToken;
            ExpiredIn = expiredIn;
        }
        public string? AccessToken { get; set; }
        public double ExpiredIn { get; set; }
    }
}
