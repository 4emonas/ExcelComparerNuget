using System.Text;
using System.Data;
using ExcelDataReader;
using ExcelCompare.Domain.Commands.Abstract;
using ExcelCompare.Domain.Models.Abstract;
using ExcelCompare.Domain.Models;

namespace ExcelCompare.Domain.Commands.Reader;

public class Reader : IReader
{
    /// <summary>
    /// Reads the content of the file.
    /// </summary>
    /// <param name="input">The file. The stream and the file name are used, in order to read the file contents</param>
    /// <returns>FileContent object</returns>
    public FileContent ReadFile(IInput input)
    {
        var result = new FileContent(input.FilePath);
        result.Content = ReadFileContent(input);
        return result;
    }

    /// <summary>
    /// Opens the file stream and reads the content of the file.
    /// </summary>
    /// <returns>List of List of objects"</returns>
    private List<List<object?>> ReadFileContent(IInput input)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        var readerMethod = CreateReaderMethod(input);
        using var stream = File.Open(input.FilePath, FileMode.Open, FileAccess.Read);
        using var reader = readerMethod(stream, null);

        do
        {
            while (reader.Read()) { }
        } while (reader.NextResult());

        var result = reader.AsDataSet();
        return result.Tables[0].AsEnumerable().Select(_ => _.ItemArray.ToList()).ToList();
    }

    /// <summary>
    /// Creates the reader method depending on the file format.
    /// </summary>
    /// <param name="input">Input file. Filename is used for this method.</param>
    private Func<Stream, ExcelReaderConfiguration, IExcelDataReader> CreateReaderMethod(IInput input)
    {
        return input.IsCsv()
            ? ExcelReaderFactory.CreateCsvReader
            : ExcelReaderFactory.CreateReader;
    }
}
