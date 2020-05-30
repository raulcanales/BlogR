using BlogR.Core.Data.Entities;
using MediatR;

namespace BlogR.Core.CQRS.Commands
{
    public class CreatePostCommand : IRequest<Post>
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public bool EnableComments { get; set; }
    }
}
