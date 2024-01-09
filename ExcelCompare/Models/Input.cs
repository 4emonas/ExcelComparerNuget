using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompareNuget.Models;

public class Input : IFileInput
{
    public string FilePath { get; set; }

    public bool IsCsv()
    {
        return FilePath.EndsWith("csv");
    }
}
