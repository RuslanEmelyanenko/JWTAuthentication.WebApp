using Authentication.Models;
using Authentication.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AuthenticationDBContext _dBContext;

        public UserRepository(AuthenticationDBContext dbContext) : base(dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            var users = await _dBContext.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetAsync(string userName)
        {
            var useremail = await _dBContext.Users.FindAsync(userName);

            return useremail;
        }

        public async Task Delete(string userEmail)
        {
            var useremail = await _dBContext.Users.FindAsync(userEmail);

            if (useremail != null)
            {
                _dBContext.Remove(useremail);
            }
        }

        public async Task CreateAsync(User user)
        {
            await _dBContext.Users.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            _dBContext.Users.Update(user);  
        }

        public async Task CompleteAsync()
        {
            await _dBContext.SaveChangesAsync();
        }
    }
}