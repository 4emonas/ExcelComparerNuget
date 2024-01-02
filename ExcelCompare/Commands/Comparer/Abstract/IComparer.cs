using ExcelCompare.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCompare.Domain.Commands.Comparer
{
    public interface IComparer
    {
        public IResult CompareInputs(IInput inputFileA, IInput inputFileB); 
    }
}
