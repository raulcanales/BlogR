using MediatR;

namespace BlogR.Core.CQRS.Events
{
    public class PostViewedEvent : INotification
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
