using System.Globalization;

namespace THPCore.Helpers;

public class LocaleHelper
{
    public static bool IsAvailable(string? locale)
    {
        if (string.IsNullOrWhiteSpace(locale)) return false;
        if (locale == "zh-CN") return true;
        var allowedLocales = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => x.Name).ToList();
        return allowedLocales.Contains(locale);
    }
}
