using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using BlogR.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogR.Core.CQRS.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var salt = SecurityHelper.GenerateSalt();
            var hashedPassword = SecurityHelper.HashString(string.Concat(request.Password, salt));

            var user = new User
            {
                Email = request.Email,
                Nickname = request.Nickname,
                Password = hashedPassword,
                Salt = salt
            };

            await _userRepository.AddAsync(user);
            return user;
        }
    }
}
