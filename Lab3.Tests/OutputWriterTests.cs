using Lab3.Library;

namespace Lab3.Tests
{
    public class OutputWriterTests
    {
        [Fact]
        public void WriteOutput_ShouldWriteCorrectly()
        {
            // Arrange
            string filePath = "output_test.txt";
            var finalStates = new HashSet<List<int>>(new ListComparer())
            {
                new List<int> { 0, 1, 0 },
                new List<int> { 1, 0, 1 }
            };

            // Act
            Utils.WriteOutput(filePath, finalStates);

            // Assert
            string[] outputLines = File.ReadAllLines(filePath);
            Assert.Equal("2", outputLines[0]);
            Assert.Contains("0 1 0", outputLines);
            Assert.Contains("1 0 1", outputLines);
        }
    }
}