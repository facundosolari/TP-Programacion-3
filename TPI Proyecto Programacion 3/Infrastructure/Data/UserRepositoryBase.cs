using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public abstract class UserRepositoryBase<T> : IUserRepository where T : User
    {
        protected readonly ProjectContext _dbContext;

        public UserRepositoryBase(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserByUsername(string username)
        {
            return _dbContext.Set<T>().FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
