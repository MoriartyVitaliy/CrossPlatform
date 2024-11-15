using System;
using System.IO;
using Lab2.Library;

namespace LabsLibrary
{
    public class Lab2Runner : ILabsRunner
    {
        public void Execute(string inputFilePath, string outputFilePath)
        {
            try
            {
                // Чтение входного файла
                var input = Utils.ReadInput(inputFilePath);
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input file is empty or unreadable.");
                    return;
                }

                // Заполнение массива агентов
                if (!Utils.FillArray(input, out int n, out Agent[] agents))
                {
                    Console.WriteLine("Error: Failed to fill agent data.");
                    return;
                }

                // Инициализация минимальных рисков и вычисление результата
                int[] minRisks = new int[n];
                minRisks[1] = agents[1].Risk;
                int result = Solution.MinValue(n, agents, minRisks);

                // Запись результата в выходной файл
                if (Utils.WriteOutput(outputFilePath, result))
                {
                    Console.WriteLine("File created successfully with the result.");
                }
                else
                {
                    Console.WriteLine("Error: Failed to write to output file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
