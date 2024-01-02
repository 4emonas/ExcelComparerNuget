using ExcelCompare.Domain.Models.Abstract;

namespace ExcelCompare.Domain.Models;

public class Result : IResult
{
    public List<string?> CellsOnlyInFileA { get; internal set; }
    public List<string?> CellsOnlyInFileB { get; internal set; }
    public List<string?> CellsWithDifferentValues { get; internal set; }

    public Result(List<string?> cellsOnlyInFileA, List<string?> cellsOnlyInFileB, List<string?> cellsWithDifferentValues)
    {
        CellsOnlyInFileA = cellsOnlyInFileA;
        CellsOnlyInFileB = cellsOnlyInFileB;
        CellsWithDifferentValues = cellsWithDifferentValues;
    }
}
