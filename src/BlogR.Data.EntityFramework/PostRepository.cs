using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogR.Data.EntityFramework
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context) { }

        public new async Task<Post> SingleOrDefaultAsync(Expression<Func<Post, bool>> predicate)
            => await Entities.Include(p => p.Author).SingleOrDefaultAsync(predicate);

        public new PagedResult<Post> GetList(Expression<Func<Post, bool>> predicate, int page = 1, int elementsPerPage = 10)
        {
            if (predicate != null)
                return Entities.Where(predicate).Include(p => p.Author).GetPaged(page, elementsPerPage);

            return Entities.Include(p => p.Author).GetPaged(page, elementsPerPage);
        }
    }
}
