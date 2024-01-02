
namespace ExcelCompare.Domain.Helpers;

public static class CellHelper
{
    /// <summary>
    /// Translates a column index number to a letter
    /// </summary>
    /// <returns>Example index 4 gets translated to D</returns>
    public static string GetExcelColumnName(int columnNumber)
    {
        var columnName = string.Empty;

        while (columnNumber > 0)
        {
            int modulo = (columnNumber - 1) % 26;
            columnName = Convert.ToChar('A' + modulo) + columnName;
            columnNumber = (columnNumber - modulo) / 26;
        }

        return columnName;
    }
}
