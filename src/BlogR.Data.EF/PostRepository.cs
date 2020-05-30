using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Data.EF
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {
        }

        public Task IncreaseViewCountAsync(int postId, CancellationToken token = default)
        {
            return null;
        }
    }
}
