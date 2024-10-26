using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class UserRepository : UserRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectContext dbContext) : base(dbContext) { }
    }
}
