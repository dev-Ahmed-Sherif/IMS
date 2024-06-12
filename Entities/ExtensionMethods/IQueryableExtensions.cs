using Entities.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Entities.ExtensionMethods
{
    public static class IQueryableExtensions
    {
        public static PaginatedResult<TResult> ToPaginatedResult<T, TResult>(this IQueryable<T> source, int index, int size, Expression<Func<T, TResult>> selector)
        {
            if (index < 0) index = 0;
            if (size <= 0) size = int.MaxValue;
            return
            new PaginatedResult<TResult>
            {
                Items = source.Skip(index * size).Take(size).Select(selector).ToList(),
                Page = index,
                PageSize = size,
                TotalItems = source.Count()
            };
        }

        public static IQueryable<T> ToPaginatedResultUnMapped<T>(this IQueryable<T> source, PaginationInputViewModel pagination)
        {
            if (pagination.Index < 0) pagination.Index = 0;
            if (pagination.Size <= 0) pagination.Size = int.MaxValue;
            return source.Skip(pagination.Index * pagination.Size).Take(pagination.Size);
        }
    }
}
