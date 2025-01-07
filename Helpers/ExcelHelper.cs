using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace THPCore.Helpers;

public class ExcelHelper
{
    public const string ExcelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    /// <summary>
    /// Apply borders to the given range of cells
    /// </summary>
    /// <param name="cells"></param>
    public static void ApplyBordersToRange(ExcelRange cells)
    {
        cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
    }
}
