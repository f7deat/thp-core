namespace THPCore.Interfaces;

public interface IFilterOptions : ILocale
{
    int Current { get; set; }
    int PageSize { get; set; }
}
