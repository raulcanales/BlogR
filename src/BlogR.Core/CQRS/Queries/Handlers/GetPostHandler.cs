using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Queries.Handlers
{
    public class GetPostHandler : IRequestHandler<GetPost, Post>
    {
        private readonly IPostRepository _postRepository;

        public GetPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.SingleOrDefaultAsync(p => p.Slug == request.Slug);
            return post;
        }
    }
}
