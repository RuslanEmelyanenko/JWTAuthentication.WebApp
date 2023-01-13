using Authentication.Models;
using Authentication.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected DbSet<T> Entities { get; set; }
        protected AuthenticationDBContext DbContext { get; set; }

        protected BaseRepository(AuthenticationDBContext dbContext)
        {
            DbContext = dbContext;
            Entities = dbContext.Set<T>();
        }

        public async Task CompleteAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            Entities.Remove(entity);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task GetAsync(T entity)
        {
            await Entities.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Update(entity);
        }
    }
}