using ExcelCompareNuget.Commands.Comparer;
using ExcelCompareNuget.Compare.Entities;
using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompare.Public.Commands.Abstract;

public class ExcelpCompareCommands : IExcelpCompareCommands
{

    private readonly IComparer _comparer;

    public ExcelpCompareCommands()
    {
        _comparer = new Comparer();
    }

    public CompareResponse CompareFiles(IFileInput inputFileA, IFileInput inputFileB)
    {
        return _comparer.CompareInputs(inputFileA, inputFileB);
    }
}
