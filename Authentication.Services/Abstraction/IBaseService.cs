namespace Authentication.Services.Abstraction
{
    public interface IBaseService<T> 
        where T : class
    {
        Task DeleteUserAsync(string entity);
        Task CreateUserAsync(T entity);
    }
}