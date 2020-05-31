using BlogR.Core.Data.Entities;
using BlogR.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        PagedResult<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, int page = 1, int elementsPerPage = 10);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        Task UpdateAsync(TEntity entity, CancellationToken token = default);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        Task RemoveAsync(TEntity entity, CancellationToken token = default);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
    }
}
