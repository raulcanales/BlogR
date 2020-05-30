using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Commands.Handlers
{
    public class ValidateLoginCommandHandler : IRequestHandler<ValidateLoginCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ValidateLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ValidateLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SingleOrDefaultAsync(u => u.Email == request.Email.ToLower());

            if (user == null)
                return false;

            var hashedPassword = SecurityHelper.HashString(string.Concat(request.Password, user.Salt));
            return hashedPassword == user.Password;
        }
    }
}
