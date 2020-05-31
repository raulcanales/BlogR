using BlogR.Core.Data.Entities;
using MediatR;

namespace BlogR.Core.CQRS.Queries
{
    public class GetPost : IRequest<Post>
    {
        public string Slug { get; set; }
    }
}
