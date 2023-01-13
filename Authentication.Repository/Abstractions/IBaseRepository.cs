namespace Authentication.Repository.Abstractions
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task GetAsync(T entity);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task CompleteAsync();
    }
}