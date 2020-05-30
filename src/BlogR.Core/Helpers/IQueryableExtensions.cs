using BlogR.Core.Data.Entities;
using System;
using System.Linq;

namespace BlogR.Core.Helpers
{
    public static class IQueryableExtensions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int elementsPerPage) where T : BaseEntity
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                ElementsPerPage = elementsPerPage,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / elementsPerPage;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * elementsPerPage;
            result.Results = query.Skip(skip).Take(elementsPerPage).ToList();

            return result;
        }
    }
}
