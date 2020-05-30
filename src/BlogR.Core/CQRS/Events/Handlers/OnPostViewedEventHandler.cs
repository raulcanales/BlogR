using BlogR.Core.Data.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Events.Handlers
{
    public class OnPostViewedEventHandler : INotificationHandler<PostViewedEvent>
    {
        private readonly IPostRepository _postRepository;

        public OnPostViewedEventHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Task Handle(PostViewedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
