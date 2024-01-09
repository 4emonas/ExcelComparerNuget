
using ExcelCompareNuget.Compare.Entities;
using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompare.Public.Commands.Abstract;

public interface IExcelpCompareCommands
{
    public CompareResponse CompareFiles(IFileInput inputFileA, IFileInput inputFileB);
}
