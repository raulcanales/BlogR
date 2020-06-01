using BlogR.Core.CQRS.Commands;
using BlogR.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("/register")]
        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [Route("/register")]
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _mediator.Send(new RegisterUserCommand
            {
                Email = model.Email,
                Nickname = model.Nickname,
                Password = model.Password
            });

            return RedirectToAction("Login");
        }

        [Route("/login")]
        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var isValidLogin = await _mediator.Send(new ValidateLoginCommand
            {
                Email = model.Email,
                Password = model.Password
            });

            if (!isValidLogin)
            {
                ModelState.AddModelError(string.Empty, "Invalid login or password");
                return View(model);
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email, model.Email));

            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties { IsPersistent = model.RememberMe };
            await HttpContext.SignInAsync(principal, properties).ConfigureAwait(false);

            return LocalRedirect(returnUrl ?? "/");
        }
    }
}
