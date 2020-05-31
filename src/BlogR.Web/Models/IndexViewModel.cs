using BlogR.Core.Data.Entities;
using BlogR.Core.Helpers;

namespace BlogR.Web.Models
{
    public class IndexViewModel
    {
        public PagedResult<Post> Posts { get; set; }
    }
}
