namespace ExcelCompareNuget.Models.Abstract;

public interface IFileInput
{
    public string FilePath { get; }

    /// <summary>
    /// Uses FilePath to determine wether the file is a CSV file or not.
    /// </summary>
    public bool IsCsv();
}
