using BlogR.Core.CQRS.Queries;
using BlogR.Core.Data.Entities;
using BlogR.Core.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/comments")]
        public async Task<PagedResult<Comment>> GetComments(int postId, int page = 1)
        {
            var comments = await _mediator.Send(new GetComments
            {
                PostId = postId,
                Page = page
            });
            return comments;
        }
    }
}
