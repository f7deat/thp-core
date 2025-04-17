using Microsoft.EntityFrameworkCore;
using THPCore.Interfaces;

namespace THPCore.Models;

public class ListResult<T> where T : class
{
    public ListResult(string? message)
    {
        Message = message;
    }

    public ListResult(IEnumerable<T> data, int total, IFilterOptions filterOptions)
    {
        Data = data;
        Total = total;
        FilterOptions = filterOptions;
    }

    private readonly IFilterOptions FilterOptions = new FilterOptions();
    public string? Message { get; set; }
    public IEnumerable<T> Data { get; set; } = [];
    public int Total { get; set; }
    public bool Succeeded { get; } = true;

    public bool HasNextPage => Total > FilterOptions.Current * FilterOptions.PageSize;
    public bool HasPreviousPage => FilterOptions.Current > 1;
    public int Current => FilterOptions.Current;
    public int PageSize => FilterOptions.PageSize;

    public static async Task<ListResult<T>> Success(IQueryable<T> query, IFilterOptions filterOptions)
    {
        if (filterOptions.Current < 1) filterOptions.Current = 1;
        if (filterOptions.PageSize > 1000) filterOptions.PageSize = 1000;
        return new ListResult<T>(await query.AsNoTracking().Skip((filterOptions.Current - 1) * filterOptions.PageSize).Take(filterOptions.PageSize).ToListAsync(), await query.CountAsync(), filterOptions);
    }

    public static ListResult<T> Failed(string? message) => new(message);
}
