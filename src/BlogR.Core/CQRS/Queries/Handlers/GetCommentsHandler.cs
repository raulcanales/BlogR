using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Queries.Handlers
{
    public class GetCommentsHandler : IRequestHandler<GetComments, PagedResult<Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<PagedResult<Comment>> Handle(GetComments request, CancellationToken cancellationToken)
        {
            if (request.Page < 1) request.Page = 1;
            var comments = _commentRepository.GetList(x => x.PostId.Equals(request.PostId), request.Page, 20);
            return Task.FromResult(comments);
        }
    }
}
