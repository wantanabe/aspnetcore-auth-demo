using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AuthDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthDemo.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> _dbSet;
        public readonly ILogger _logger;

        public RepositoryBase(AuthDemoDbContext context, ILogger logger)
        {
            _dbSet = context.Set<TEntity>();
            _logger = logger;
        }

        public virtual Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
