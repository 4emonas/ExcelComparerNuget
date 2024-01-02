using ExcelCompare.Domain.Commands.Abstract;
using ExcelCompare.Domain.Models.Abstract;
using ExcelCompare.Domain.Models;

namespace ExcelCompare.Domain.Commands.Comparer;

public class Comparer : IComparer
{
    private readonly IReader _reader;

    public Comparer()
    {
        _reader = new Reader.Reader();
    }

    public IResult CompareInputs(IInput inputFileA, IInput inputFileB)
    {
        var cellsOnlyInFileA = new List<string?>();
        var cellsOnlyInFileB = new List<string?>();
        var cellsWithDifferentValues = new List<string?>();

        var fileContentA = _reader.ReadFile(inputFileA);
        var fileContentB = _reader.ReadFile(inputFileB);

        ValidateInputs(fileContentA, fileContentB);

        var minRows = 0;
        if (fileContentA.Content!.Count > fileContentB.Content!.Count) //file A has more rows
        {
            minRows = fileContentB.Content.Count;
            IterateThroughFileRows(minRows, fileContentA.Content.Count, fileContentA, cellsOnlyInFileA);
        }
        else if (fileContentB.Content.Count > fileContentA.Content.Count) //file B has more rows
        {
            minRows = fileContentA.Content.Count;
            IterateThroughFileRows(minRows, fileContentB.Content.Count, fileContentB, cellsOnlyInFileB);
        }

        IterateThroughRestOfFile(minRows, fileContentA, fileContentB, cellsOnlyInFileA, cellsOnlyInFileB, cellsWithDifferentValues);

        return new Result(cellsOnlyInFileA, cellsOnlyInFileB, cellsWithDifferentValues);
    }

    private void ValidateInputs(FileContent fileContentA, FileContent fileContentB)
    {
        if (fileContentA.Content == null || fileContentB.Content == null)
        {
            throw new ArgumentNullException($"Unable to read one or both of the input files.");
        }
    }
    public void IterateThroughFileRows(int minRows, int maxRows, FileContent fileContent, List<string?> listDestination)
    {
        for (int i = minRows; i <= maxRows - 1; i++)
        {
            IterateThroughFileColumns(0, fileContent.Content[i], i, listDestination);
        }
    }

    public void IterateThroughFileColumns(int minColumns, List<object?> row, int rowIndex, List<string?> listDestination)
    {
        for (int j = minColumns; j < row.Count; j++)
        {
            if (!string.IsNullOrEmpty(row[j].ToString()))
            {
                listDestination.Add(new CellLocation(rowIndex, j).ToString());
            }
        }
    }

    public void IterateThroughRestOfFile(int minRows, FileContent fileContentA, FileContent fileContentB, List<string?> cellsOnlyInFileA, List<string?> cellsOnlyInFileB, List<string?> cellsWithDifferentValues)
    {
        for (int i = 0; i < minRows; i++)
        {
            var rowA = fileContentA.Content![i];
            var rowB = fileContentB.Content![i];

            var columnsInRowA = rowA.Count;
            var columnsInRowB = rowB.Count;
            var minColumns = 0;

            if (columnsInRowA > columnsInRowB) //row A has more columns
            {
                minColumns = columnsInRowB;
                IterateThroughFileColumns(minColumns, rowA, i, cellsOnlyInFileA);
            }
            else if (columnsInRowB > columnsInRowA) //row B has more columns
            {
                minColumns = columnsInRowA;
                IterateThroughFileColumns(minColumns, rowB, i, cellsOnlyInFileB);
            }

            CompareCommonCells(minColumns, i, rowA, rowB, cellsOnlyInFileA, cellsOnlyInFileB, cellsWithDifferentValues); //rest of file
        }
    }

    public void CompareCommonCells(int minColumns, int rowIndex, List<object?> rowA, List<object?> rowB, List<string?> cellsOnlyInFileA, List<string?> cellsOnlyInFileB, List<string?> cellsWithDifferentValues)
    {
        for (int j = 0; j < minColumns; j++)
        {
            if (string.IsNullOrEmpty(rowA[j].ToString()) && !string.IsNullOrEmpty(rowB[j].ToString()))
            {
                cellsOnlyInFileB.Add(new CellLocation(rowIndex, j).ToString());
            }
            else if (string.IsNullOrEmpty(rowB[j].ToString()) && !string.IsNullOrEmpty(rowA[j].ToString()))
            {
                cellsOnlyInFileA.Add(new CellLocation(rowIndex, j).ToString());
            }
            else if (!string.Equals(rowA[j].ToString(), rowB[j].ToString()))
            {
                cellsWithDifferentValues.Add(new CellLocation(rowIndex, j).ToString());
            }
        }
    }

}
