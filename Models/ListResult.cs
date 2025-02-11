using Microsoft.EntityFrameworkCore;
using THPCore.Interfaces;

namespace THPCore.Models;

public class ListResult<T>(IEnumerable<T> data, int total, IFilterOptions filterOptions) where T : class
{
    public IEnumerable<T> Data { get; set; } = data;
    public int Total { get; set; } = total;
    public bool Succeeded { get; } = true;

    public bool HasNextPage => Total > filterOptions.Current * filterOptions.PageSize;
    public bool HasPreviousPage => filterOptions.Current > 1;
    public bool HasData => Data.Any();
    public int Current => filterOptions.Current;
    public int PageSize => filterOptions.PageSize;

    public static async Task<ListResult<T>> Success(IQueryable<T> query, IFilterOptions filterOptions)
    {
        if (filterOptions.Current < 1) filterOptions.Current = 1;
        if (filterOptions.PageSize > 1000) filterOptions.PageSize = 1000;
        return new ListResult<T>(await query.AsNoTracking().Skip((filterOptions.Current - 1) * filterOptions.PageSize).Take(filterOptions.PageSize).ToListAsync(), await query.CountAsync(), filterOptions);
    }
}
