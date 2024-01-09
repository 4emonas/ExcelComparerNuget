using ExcelCompareNuget.Compare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCompareNuget.Compare.Command.Abstract
{
    public interface ICompareCommand
    {
        public CompareResponse CompareInputs(CompareRequest compareRequest);
    }
}
