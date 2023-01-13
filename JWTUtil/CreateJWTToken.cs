using JWTUtil.Abstraction;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWTUtil
{
    public class CreateJWTToken : ICreateJWTToken
    {
        private readonly JWTToken _jwtTokenOptions;

        public CreateJWTToken(IOptions<JWTToken> jwtTokenOptions)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        public string GenerateJWT(string email, string password)
        {
            var authParams = _jwtTokenOptions;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Sub, password)
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            var ecodetJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return ecodetJwt;
        }
    }
}