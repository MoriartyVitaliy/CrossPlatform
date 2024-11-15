using Lab1.Library;
using System;
using System.IO;

namespace Lab1.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            var converter = new PositionConverter();
            var calculator = new KnightMoveCalculator();

            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\INPUT.txt");
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\OUTPUT.txt");

            try
            {
                var input = fileService.ReadInput(inputFilePath);
                var startCoordinates = converter.Convert(input[0]);
                var endCoordinates = converter.Convert(input[1]);
                var result = calculator.GetMinimumMoves(startCoordinates, endCoordinates);

                Console.WriteLine($"result: {result}");
                fileService.WriteOutput(outputFilePath, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
