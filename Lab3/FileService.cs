using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class FileService
    {
        public List<int> ReadInitialState(string inputFilePath)
        {
            string[] inputLines = File.ReadAllLines(inputFilePath);
            int n = int.Parse(inputLines[0]);
            List<int> initialState = new List<int>(Array.ConvertAll(inputLines[1].Split(), int.Parse));
            return initialState;
        }

        public bool[,] ReadDestructionMatrix(string inputFilePath, int n)
        {
            bool[,] destructionMatrix = new bool[n, n];
            string[] inputLines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < n; i++)
            {
                var line = Array.ConvertAll(inputLines[i + 2].Split(), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    destructionMatrix[i, j] = (line[j] != 0);
                }
            }
            return destructionMatrix;
        }

        public void WriteResults(string outputFilePath, HashSet<List<int>> finalStates)
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
