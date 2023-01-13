using JWTUtil.Abstraction;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWTUtil
{
    public class JWTToken : IJWTToken
    {
        public const string JWTAuth = "JWTToken";  // Json - "JWTToken"

        public string Issuer { get; set; } = string.Empty; // издатель токена
        public string Audience { get; set; } = string.Empty; // потребитель токена
        public string SecretKey { get; set; } = string.Empty;   // ключ для шифрации
        public int TokenLifeTime { get; set; } // время жизни токена в минутах

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}