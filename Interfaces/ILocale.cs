namespace THPCore.Interfaces;

/// <summary>
/// Represents a locale identifier, typically used to specify a language or regional setting.
/// </summary>
/// <remarks>The <see cref="ILocale"/> interface provides a mechanism to get or set the locale as a string. The
/// locale is commonly represented in formats such as "en-US" for English (United States) or "fr-FR" for French
/// (France).</remarks>
public interface ILocale
{
    /// <summary>
    /// Gets or sets the locale used for formatting and localization.
    /// </summary>
    /// <remarks>The locale determines the language and cultural conventions used for operations such as date,
    /// time, and number formatting. Ensure the value is a valid locale identifier supported by the system.</remarks>
    string Locale { get; set; }
}
