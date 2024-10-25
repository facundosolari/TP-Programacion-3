using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : UserRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectContext dbContext) : base(dbContext) { }
    }
}
