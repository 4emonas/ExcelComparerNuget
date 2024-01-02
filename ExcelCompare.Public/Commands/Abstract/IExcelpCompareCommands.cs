
using ExcelCompare.Domain.Models.Abstract;

namespace ExcelCompare.Public.Commands.Abstract;

public interface IExcelpCompareCommands
{
    public IResult CompareFiles(IInput inputFileA, IInput inputFileB);
}
