using BlogR.Core.Data.Entities;
using BlogR.Core.Helpers;
using MediatR;

namespace BlogR.Core.CQRS.Queries
{
    public class GetComments : IRequest<PagedResult<Comment>>
    {
        public int PostId { get; set; }
        public int Page { get; set; } = 1;
    }
}
