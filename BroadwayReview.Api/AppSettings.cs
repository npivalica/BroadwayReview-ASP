using BroadwayReview.Api.Auth;

namespace BroadwayReview.Api
{
    public class AppSettings
    {
        public string ConString { get; set; }
        public JWTSettings JwtSettings { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPassword { get; set; }
    }
}
