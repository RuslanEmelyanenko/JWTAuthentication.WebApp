using Authentication.Dtos;
using Authentication.Models;
using Authentication.Repository.Abstractions;
using Authentication.Services.Abstraction;
using AutoMapper;

namespace Authentication.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(UserDto createUser)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var user = users.FirstOrDefault(user => user.Email == createUser.Email);

            if(user == null)
            {
                user = new User
                {
                    UserName = createUser.UserName,
                    Email = createUser.Email,
                    Password = createUser.Password
                };

                await _unitOfWork.UserRepository.CreateAsync(user);
                await _unitOfWork.UserRepository.CompleteAsync();
            }
            else
            {
                Console.WriteLine("Error! A user with the same name already exists!");
            }
        }

        public async Task DeleteUserAsync(string userName)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(userName);

            if(user != null)
            {
                await _unitOfWork.UserRepository.DeleteAsync(user);
                await _unitOfWork.UserRepository.CompleteAsync();
            }
        }
    }
}