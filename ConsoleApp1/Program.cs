// See https://aka.ms/new-console-template for more information
using ExcelCompare.Domain.Commands;
using ExcelCompare.Domain.Commands.Comparer;
using ExcelCompare.Domain.Commands.Reader;
using ExcelCompare.Domain.Models;

Console.WriteLine("Hello, World!");


var inputA = new Input();
inputA.FilePath = @"C:\Users\User\Desktop\test.xlsx";

var inputB = new Input();
inputB.FilePath = @"C:\Users\User\Desktop\test2.xlsx";

var comparer = new Comparer();
comparer.CompareInputs(inputA, inputB);