using Microsoft.AspNetCore.Mvc;

namespace BlogR.Web.Areas.Admin.Controllers
{
    [Route("admin")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
