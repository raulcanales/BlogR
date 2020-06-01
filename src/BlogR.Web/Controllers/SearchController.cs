using BlogR.Core.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;
        const int ElementsPerPage = 10;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string q, int page = 1)
        {
            var posts = await _mediator.Send(new GetPosts
            {
                Page = page,
                ElementsPerPage = ElementsPerPage,
                Predicate = (p => p.Content.Contains(q))
            });

            return View("Search", posts);
        }
    }
}
