using ExcelCompareNuget.Helpers;

namespace ExcelCompareNuget.Models;

public class CellLocation
{
    public CellLocation(int rowNumber, int columnNumber)
    {
        RowNumber = rowNumber;
        ColumnNumber = columnNumber;
    }

    public int RowNumber { get; internal set; }
    public int ColumnNumber { get; internal set; }

    public override string ToString()
    {
        return $"{CellHelper.GetExcelColumnName(ColumnNumber + 1)}{RowNumber + 1}";
    }
}
