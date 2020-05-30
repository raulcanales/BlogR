using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Queries.Handlers
{
    public class GetPostHandler : IRequestHandler<GetPost, User>
    {
        public GetPostHandler(IPostRepository postRepository)
        {

        }

        public Task<User> Handle(GetPost request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
