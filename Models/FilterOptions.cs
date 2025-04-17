using THPCore.Interfaces;

namespace THPCore.Models;

public class FilterOptions : IFilterOptions, ILocale
{
    public int Current { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string Locale { get; set; } = "vi-VN";
}
