using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompareNuget.Models;

public class FileInput : IFileInput
{
    public string FilePath { get; set; }

    public bool IsCsv()
    {
        return FilePath.EndsWith("csv");
    }
}
