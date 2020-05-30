using MediatR;

namespace BlogR.Core.CQRS.Commands
{
    public class ValidateLoginCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
