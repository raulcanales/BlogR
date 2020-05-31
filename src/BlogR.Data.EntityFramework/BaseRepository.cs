using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Data.EntityFramework
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> Entities { get; }
        protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public PagedResult<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, int page = 1, int elementsPerPage = 10)
        {
            if (predicate == null)
                return Entities.GetPaged(page, elementsPerPage);

            return Entities.Where(predicate).GetPaged(page, elementsPerPage);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await Entities.SingleOrDefaultAsync(predicate);

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Entities.Add(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Entities.AddRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            Entities.Update(entity);
            await Context.SaveChangesAsync(token);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default)
        {
            Entities.UpdateRange(entities);
            await Context.SaveChangesAsync(token);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Entities.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Entities.RemoveRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
