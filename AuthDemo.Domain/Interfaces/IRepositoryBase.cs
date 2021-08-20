using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthDemo.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task GetAsync(Expression<Func<TEntity, bool>> expression);

        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression);
    }
}
