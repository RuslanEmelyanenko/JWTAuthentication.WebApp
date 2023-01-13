using Authentication.Dtos;

namespace Authentication.Services.Abstraction
{
    public interface IAuthService
    {
        Task<UserDto> AuthenticateUser(string email, string password);
    }
}