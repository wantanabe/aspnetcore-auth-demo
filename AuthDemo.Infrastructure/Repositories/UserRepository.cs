using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AuthDemo.Domain.Entities.Authentication;
using AuthDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthDemo.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AuthDemoDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        public override Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public override Task GetAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<User>> ListAsync(Expression<Func<User, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public override Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
