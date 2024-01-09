namespace ExcelCompareNuget.Compare.Entities;

public class CompareResponse
{
    public List<string?> CellsOnlyInFileA { get; internal set; }
    public List<string?> CellsOnlyInFileB { get; internal set; }
    public List<string?> CellsWithDifferentValues { get; internal set; }

    public CompareResponse(List<string?> cellsOnlyInFileA, List<string?> cellsOnlyInFileB, List<string?> cellsWithDifferentValues)
    {
        CellsOnlyInFileA = cellsOnlyInFileA;
        CellsOnlyInFileB = cellsOnlyInFileB;
        CellsWithDifferentValues = cellsWithDifferentValues;
    }
}
