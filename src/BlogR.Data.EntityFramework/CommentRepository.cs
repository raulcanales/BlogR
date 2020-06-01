using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogR.Data.EntityFramework
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context)
            : base(context)
        {
        }

        public new PagedResult<Comment> GetList(Expression<Func<Comment, bool>> predicate, int page = 1, int elementsPerPage = 10)
        {
            return Entities.Where(predicate)
                .Include(c => c.Author)
                .Include(c => c.ParentComment)
                .OrderByDescending(c => c.CreationTimeUtc)
                .GetPaged(page, elementsPerPage);
        }
    }
}
