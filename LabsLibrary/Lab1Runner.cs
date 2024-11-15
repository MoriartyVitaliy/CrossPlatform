using Lab1.Library;

namespace LabsLibrary
{
    public class Lab1Runner : ILabsRunner
    {
        public void Execute(string inputFilePath, string outputFilePath)
        {
            var fileService = new FileService();
            var converter = new PositionConverter();
            var calculator = new KnightMoveCalculator();

            var input = fileService.ReadInput(inputFilePath);
            var startCoordinates = converter.Convert(input[0]);
            var endCoordinates = converter.Convert(input[1]);

            var result = calculator.GetMinimumMoves(startCoordinates, endCoordinates);

            fileService.WriteOutput(outputFilePath, result);
        }
    }
}
