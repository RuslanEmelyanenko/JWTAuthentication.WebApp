using Authentication.Dtos;
using Authentication.Services.Abstraction;
using JWTUtil;
using JWTUtil.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICreateJWTToken _createJWTToken;

        public AuthenticationController(IAuthService authService, ICreateJWTToken createJWTToken)
        {
            _authService = authService;
            _createJWTToken = createJWTToken;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto request)
            {
            var user = _authService.AuthenticateUser(request.Email, request.Password);

            if(user != null)
            {
                var token = _createJWTToken.GenerateJWT(request.Email, request.Password);

                return Ok(new { Massage = "User successfully authenticated!" });
            }

            return Unauthorized();
        } 
    }
}