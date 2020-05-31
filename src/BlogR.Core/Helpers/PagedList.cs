using BlogR.Core.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlogR.Core.Helpers
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int ElementsPerPage { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * ElementsPerPage + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * ElementsPerPage, RowCount);
    }

    public class PagedResult<T> : PagedResultBase, IEnumerable<T> where T : BaseEntity
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public IEnumerator<T> GetEnumerator() => Results.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
