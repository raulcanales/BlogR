using BlogR.Core.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostController> _logger;

        public PostController(IMediator mediator, ILogger<PostController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("/post/{slug}", Name = "Post")]
        public async Task<IActionResult> Post(string slug)
        {
            var post = await _mediator.Send(new GetPost { Slug = slug });
            if (post == null || post == default)
                return NotFound();

            return View(post);
        }
    }
}
