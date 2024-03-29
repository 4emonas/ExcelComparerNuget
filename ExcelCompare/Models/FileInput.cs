using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompareNuget.Models;

public class FileInput : IFileInput
{
    public string FilePath { get; set; }

    public FileStream FileStream { get; internal set; }

    public FileInput() 
    {
        FilePath = string.Empty;
    }

    public FileInput(string filepath)
    {
        FilePath = filepath;
    }

    public FileInput(FileStream fileStream)
    {
        FileStream = fileStream;
        FilePath = fileStream.Name;
    }

    public bool IsCsv()
    {
        return FilePath.EndsWith("csv");
    }

    public bool HasStream() => FileStream != null && FileStream.Length > 0 && FileStream.CanSeek;
}
