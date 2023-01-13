using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authentication.JWTToken
{
    public class JWTToken
    {
        public string Issuer {get; set;} // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string SecretKey { get; set; }   // ключ для шифрации
        public int TokenLifeTime { get; set; } // время жизни токена в минутах

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}