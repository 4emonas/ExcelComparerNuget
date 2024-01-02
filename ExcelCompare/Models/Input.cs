using ExcelCompare.Domain.Models.Abstract;

namespace ExcelCompare.Domain.Models;

public class Input : IInput
{
    public string FilePath { get; set; }

    public bool IsCsv()
    {
        return FilePath.EndsWith("csv");
    }
}
