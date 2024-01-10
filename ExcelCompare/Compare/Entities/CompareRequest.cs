using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompareNuget.Compare.Entities;

public class CompareRequest
{
    public IFileInput InputFileA { get; }
    public IFileInput InputFileB { get; }

    public CompareRequest(IFileInput inputFileA, IFileInput inputFileB)
    {
        InputFileA = inputFileA;
        InputFileB = inputFileB;
    }
}
