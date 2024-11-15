using NuGet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class LabExecutor
    {
        private static readonly Dictionary<string, ILabsRunner> _labRunners = new Dictionary<string, ILabsRunner>
        {
            { "Lab1", new Lab1Runner() },
            { "Lab2", new Lab2Runner() },
            { "Lab3", new Lab3Runner() }
        };

        public static void ExecuteLab(string labName, string inputPath, string outputPath)
        {
            string processedLabName = ProcessLabStringName(labName);

            if (!_labRunners.ContainsKey(processedLabName))
            {
                Console.WriteLine("Error: Invalid lab name.");
                Console.WriteLine($"Available labs: {string.Join(", ", _labRunners.Keys)}");
                return;
            }

            ILabsRunner labRunner = _labRunners[processedLabName];
            try
            {
                Console.WriteLine($"Running {processedLabName}...");
                labRunner.Execute(inputPath, outputPath);
                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during execution: " + ex.Message);
            }
        }

        private static string ProcessLabStringName(string labName)
        {
            labName = labName.ToLower();
            return char.ToUpper(labName[0]) + labName.Substring(1);
        }
    }
}
