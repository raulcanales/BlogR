using BlogR.Core.Data.Entities;
using BlogR.Core.Helpers;
using MediatR;
using System;
using System.Linq.Expressions;

namespace BlogR.Core.CQRS.Queries
{
    public class GetPosts : IRequest<PagedResult<Post>>
    {
        public int Page { get; set; }
        public int ElementsPerPage { get; set; }
        public Expression<Func<Post, bool>> Predicate { get; set; }
    }
}
