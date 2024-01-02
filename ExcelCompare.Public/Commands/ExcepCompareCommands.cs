using ExcelCompare.Domain.Commands.Comparer;
using ExcelCompare.Domain.Models.Abstract;

namespace ExcelCompare.Public.Commands.Abstract;

public class ExcelpCompareCommands : IExcelpCompareCommands
{

    private readonly IComparer _comparer;

    public ExcelpCompareCommands()
    {
        _comparer = new Comparer();
    }

    public IResult CompareFiles(IInput inputFileA, IInput inputFileB)
    {
        return _comparer.CompareInputs(inputFileA, inputFileB);
    }
}
