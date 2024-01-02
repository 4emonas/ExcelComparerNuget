namespace ExcelCompare.Domain.Models.Abstract;

public interface IResult
{
    /// <summary>
    /// List if cells that have values in File A, but dont have values in File B
    /// </summary>
    public List<string> CellsOnlyInFileA { get; }

    /// <summary>
    /// List of cells that have values in File B, but dont have values in File A
    /// </summary>
    public List<string> CellsOnlyInFileB { get; }

    /// <summary>
    /// List of cells that have values in both files, but these values are different
    /// </summary>
    public List<string> CellsWithDifferentValues { get; }
}
