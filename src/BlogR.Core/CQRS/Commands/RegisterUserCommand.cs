using BlogR.Core.Data.Entities;
using MediatR;

namespace BlogR.Core.CQRS.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
