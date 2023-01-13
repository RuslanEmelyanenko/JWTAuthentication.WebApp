using Authentication.Repository.Implementations;

namespace Authentication.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
    }
}