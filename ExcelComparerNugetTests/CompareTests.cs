using ExcelCompareNuget.Compare.Entities;
using ExcelCompareNuget.Compare.Service;
using ExcelCompareNuget.Compare.Service.Abstract;
using ExcelCompareNuget.Models;

namespace ExcelComparerNugetTests
{
    public class CompareTests
    {
        private const string Csv_TestFile_Path = "TestInputFiles/csv_test.csv";
        private const string Csv_TestFile_Path_2 = "TestInputFiles/csv_test2.csv";
        private const string Csv_TestFile_Path_3 = "TestInputFiles/csv_test3.csv";
        private const string Xlsx_TestFile_Path = "TestInputFiles/excel_test.xlsx";
        private const string Xlsx_TestFile_Path_2 = "TestInputFiles/excel_test2.xlsx";

        private ICompareService _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new CompareService();
        }

        [TestCase(Csv_TestFile_Path, Csv_TestFile_Path_2)]
        [TestCase(Xlsx_TestFile_Path, Xlsx_TestFile_Path_2)]
        public void Assert_Same_File_Type_Comparison(string filePathA, string filePathB)
        {
            var fileInputA = new FileInput(filePathA);
            var fileInputB = new FileInput(filePathB);
            var compareRequest = new CompareRequest(fileInputA, fileInputB);

            var result = _subject.CompareInputs(compareRequest);
            AssertDifferenciesAreCorrect(result);
        }

        [Test]
        public void Assert_Different_File_Type_Comparison()
        {
            var fileInputA = new FileInput(Csv_TestFile_Path);
            var fileInputB = new FileInput(Xlsx_TestFile_Path_2);
            var compareRequest = new CompareRequest(fileInputA, fileInputB);

            var result = _subject.CompareInputs(compareRequest);
            AssertDifferenciesAreCorrect(result);
        }

        private void AssertDifferenciesAreCorrect(CompareResponse compareResponse)
        {
            Assert.IsNotNull(compareResponse);
            Assert.IsNotNull(compareResponse.CellsOnlyInFileA);
            Assert.IsNotNull(compareResponse.CellsOnlyInFileB);
            Assert.IsNotNull(compareResponse.CellsWithDifferentValues);

            var expectedCellsOnlyInFileA = new[] { "A5", "B5", "C5", "E8" };
            var expectedCellsOnlyInFileB = new[] { "D1", "D2", "A3", "D3", "D4" };
            var expectedCellsWithDifferentValues = new[] { "B2" };

            Assert.That(compareResponse.CellsOnlyInFileA, Is.EqualTo(expectedCellsOnlyInFileA));
            Assert.That(compareResponse.CellsOnlyInFileB, Is.EqualTo(expectedCellsOnlyInFileB));
            Assert.That(compareResponse.CellsWithDifferentValues, Is.EqualTo(expectedCellsWithDifferentValues));
        }

        [Test]
        [Description("When 2 NxM files are being compared")]
        public void AssertSameSizeFileComparrison()
        {
            var fileInputA = new FileInput(Csv_TestFile_Path_2);
            var fileInputB = new FileInput(Csv_TestFile_Path_3);
            var compareRequest = new CompareRequest(fileInputA, fileInputB);

            var result = _subject.CompareInputs(compareRequest);
            Assert.That(result.CellsWithDifferentValues.Count(), Is.EqualTo(1));
            Assert.That(result.CellsWithDifferentValues.First(), Is.EqualTo("D4"));
        }
    }
}