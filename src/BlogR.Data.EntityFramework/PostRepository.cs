using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogR.Data.EntityFramework
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {
        }

        public new PagedResult<Post> GetList(Expression<Func<Post, bool>> predicate, int page = 1, int elementsPerPage = 10)
        {
            var criteria = Entities.Include(p => p.Author);

            if (predicate != null)
                criteria = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Post, User>)criteria.Where(predicate);

            return criteria.GetPaged(page, elementsPerPage);
        }
    }
}
