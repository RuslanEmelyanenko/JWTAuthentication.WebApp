using Authentication.Dtos;
using Authentication.Repository.Abstractions;
using Authentication.Services.Abstraction;
using AutoMapper;

namespace Authentication.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> AuthenticateUser(string email, string password)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}