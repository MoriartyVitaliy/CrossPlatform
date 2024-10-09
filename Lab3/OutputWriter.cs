using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class OutputWriter
    {
        public static void WriteOutput(string outputFilePath, HashSet<List<int>> finalStates)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(finalStates.Count);
                foreach (var state in finalStates)
                {
                    writer.WriteLine(string.Join(" ", state));
                }
            }
        }
    }
}
