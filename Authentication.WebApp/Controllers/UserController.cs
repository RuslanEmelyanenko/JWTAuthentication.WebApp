using Authentication.Dtos;
using Authentication.Models;
using Authentication.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("user")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userName)
        {
                await _userService.CreateUserAsync(userName);

                return Ok(new { Message = "Create successfaly!" });
        }

        [Route("user")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            await _userService.DeleteUserAsync(userName);

            return Ok(new { Message = "Deleted successfally!" }); 
        }
    }
}
