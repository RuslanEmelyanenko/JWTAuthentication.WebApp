using Authentication.Models;
using Authentication.Repository.Abstractions;

namespace Authentication.Repository.Implementations
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private AuthenticationDBContext dbContext = new AuthenticationDBContext();
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if( _userRepository == null)
                {
                    _userRepository = new UserRepository(dbContext);
                }

                return _userRepository;
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}