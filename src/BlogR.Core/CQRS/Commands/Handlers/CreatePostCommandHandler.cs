using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Commands.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var slug = request.Title.ToSlug();
            var post = new Post
            {
                UserId = request.AuthorId,
                Title = request.Title,
                Summary = request.Summary,
                Content = request.Content,
                Slug = slug
            };

            await _postRepository.AddAsync(post, cancellationToken);
            return post;
        }
    }
}
