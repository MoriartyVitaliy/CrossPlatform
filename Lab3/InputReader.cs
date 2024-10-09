using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class InputReader
    {
        public static (int n, List<int> particles, bool[,] destructionMatrix) ReadInput(string inputFilePath)
        {
            string[] inputLines = File.ReadAllLines(inputFilePath);

            int n = int.Parse(inputLines[0]);
            List<int> particles = new List<int>(Array.ConvertAll(inputLines[1].Split(), int.Parse));

            bool[,] destructionMatrix = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                var line = Array.ConvertAll(inputLines[i + 2].Split(), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    destructionMatrix[i, j] = (line[j] != 0);
                }
            }

            return (n, particles, destructionMatrix);
        }
    }
}
