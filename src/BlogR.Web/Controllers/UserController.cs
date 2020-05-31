using BlogR.Core.CQRS.Commands;
using BlogR.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userRegistered = await _mediator.Send(new RegisterUserCommand
            {
                Email = model.Email,
                Nickname = model.Nickname,
                Password = model.Password
            });

            return View();
        }
    }
}
