using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    internal interface ILabsRunner
    {
        void Execute(string inputFilePath, string outputFilePath);
    }
}
