using ExcelCompareNuget.Compare.Entities;

namespace ExcelCompareNuget.Compare.Service.Abstract;

public interface ICompareService
{
    public CompareResponse CompareInputs(CompareRequest compareRequest);
}
