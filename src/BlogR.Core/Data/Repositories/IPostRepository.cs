using BlogR.Core.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.Data.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task IncreaseViewCountAsync(int postId, CancellationToken token = default);
    }
}
