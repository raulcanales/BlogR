using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Queries.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPosts, PagedResult<Post>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Task<PagedResult<Post>> Handle(GetPosts request, CancellationToken cancellationToken)
        {
            if (request.Page < 1) request.Page = 1;
            if (request.ElementsPerPage < 1) request.ElementsPerPage = 1;

            var posts = _postRepository.GetList(request.Predicate, request.Page, request.ElementsPerPage);
            return Task.FromResult(posts);
        }
    }
}
