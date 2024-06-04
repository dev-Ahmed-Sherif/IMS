using System.Collections.Generic;
using System.Linq;

namespace Entities.ViewModels
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class PaginatedResultUnMapped<T>
    {
        public IQueryable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
