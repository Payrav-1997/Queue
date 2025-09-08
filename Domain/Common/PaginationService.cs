using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common;

public class PaginationService<T>(IQueryable<T> queryable)
{
    public async Task<PagedResult<T>> GetPagedResultAsync(
        int page, int size, params Expression<Func<T, bool>>[]? filters)
    {
        var query = queryable;

        if (filters != null && filters.Length > 0)
        {
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
        }

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / size);

        var items = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        var pagedResult = new PagedResult<T>
        {
            Page = page,
            Size = size,
            TotalCount = totalCount,
            TotalPages = totalPages,
            Items = items
        };

        return pagedResult;
    }
}