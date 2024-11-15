using Lab3.Library;

namespace Lab3.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public void ReadInput_ShouldParseCorrectly()
        {
            // Arrange
            string filePath = "input_test.txt";
            File.WriteAllLines(filePath, new[]
            {
                "3",
                "2 1 0",
                "1 0 1",
                "0 1 1",
                "1 1 0"
            });

            // Act
            var (n, particles, destructionMatrix) = Utils.ReadInput(filePath);

            // Assert
            Assert.Equal(3, n);
            Assert.Equal(new List<int> { 2, 1, 0 }, particles);
            Assert.True(destructionMatrix[0, 0]);
            Assert.True(destructionMatrix[1, 2]);
            Assert.True(destructionMatrix[2, 1]);
        }
    }
}