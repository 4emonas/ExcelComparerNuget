using ExcelCompareNuget.Models;
using ExcelCompareNuget.Models.Abstract;

namespace ExcelCompareNuget.Read.Abstract;

public interface IReader
{
    /// <summary>
    /// Reads the content of the file.
    /// </summary>
    /// <param name="input">The file. The stream and the file name are used, in order to read the file contents</param>
    /// <returns>FileContent object</returns>
    public FileContent ReadFile(IFileInput input);
}
