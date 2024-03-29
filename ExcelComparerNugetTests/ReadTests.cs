using ExcelCompareNuget.Models;
using ExcelCompareNuget.Read;
using ExcelCompareNuget.Read.Abstract;

namespace ExcelComparerNugetTests
{
    public class ReadTests
    {
        private const string Csv_TestFile_Path = "TestInputFiles/csv_test.csv";
        private const string Xlsx_TestFile_Path = "TestInputFiles/excel_test.xlsx";

        private IReaderService _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new ReaderService();
        }

        [TestCase(Csv_TestFile_Path, 8)]
        [TestCase(Xlsx_TestFile_Path, 8)]
        public void Reader_Uses_Correct_ReadMethod(string filePath, int fileContentSize)
        {
            var fileInput = new FileInput()
            {
                FilePath = filePath
            };

            var result = _subject.ReadFile(fileInput);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.That(result.Content.Count, Is.EqualTo(fileContentSize));
        }

        [Test]
        public void Reader_Reads_FileStream()
        {
            var fileStream = new FileStream(Csv_TestFile_Path, FileMode.Open);
            var fileInput = new FileInput(fileStream);

            var result = _subject.ReadFile(fileInput);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.That(result.Content.Count, Is.EqualTo(8));
        }

        [Test]
        public void Assert_Full_File_Read()
        {
            var fileStream = new FileStream(Csv_TestFile_Path, FileMode.Open);
            var fileInput = new FileInput(fileStream);

            var expected = new List<List<object>>()
            {
                new List<object>(){"12","23","34","",""},
                new List<object>(){"45","567","67","",""},
                new List<object>(){"","89","90","",""},
                new List<object>(){"44a","44b","44c","",""},
                new List<object>(){"55a","55b","55c","",""},
                new List<object>(){"","","","",""},
                new List<object>(){"","","","",""},
                new List<object>(){"","","","", "test"}
            };

            var result = _subject.ReadFile(fileInput);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.That(result.Content, Is.EqualTo(expected));
        }
    }
}