
namespace ExcelCompareNuget.Models;

public class FileContent
{
    public FileContent(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; set; }
    public List<List<object?>>? Content { get; set; }
}
