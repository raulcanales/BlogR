using BlogR.Core.Data.Entities;
using MediatR;

namespace BlogR.Core.CQRS.Commands
{
    public class EditPost : IRequest<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
    }
}
