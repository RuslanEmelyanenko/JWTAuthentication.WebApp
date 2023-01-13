using Microsoft.IdentityModel.Tokens;

namespace JWTUtil.Abstraction
{
    public interface IJWTToken
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        string SecretKey { get; set; }
        int TokenLifeTime { get; set; }

        SymmetricSecurityKey GetSymmetricSecurityKey();
    }
}