using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogR.Data.EntityFramework
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context)
            : base(context)
        {
        }
    }
}
