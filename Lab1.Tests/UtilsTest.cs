namespace Lab1.Tests
{
    public class UtilsTest
    {
        [Theory]
        [InlineData(new string[] { "a1", "b3" }, true, 0, 0, 1, 2)]
        [InlineData(new string[] { "h8", "a1" }, true, 7, 7, 0, 0)]
        [InlineData(new string[] { "a1", "i9" }, false, 0, 0, -1, -1)]
        public void GetCoordinates_ValidInput_ReturnsCorrectValues(string[] positions, bool expectedResult, int expectedStartX, int expectedStartY, int expectedEndX, int expectedEndY)
        {
            int startX, startY, endX, endY;
            bool result = Utils.GetCoordinates(positions, out startX, out startY, out endX, out endY);

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedStartX, startX);
            Assert.Equal(expectedStartY, startY);
            Assert.Equal(expectedEndX, endX);
            Assert.Equal(expectedEndY, endY);
        }

        [Theory]
        [InlineData("a1", true, 0, 0)]
        [InlineData("h8", true, 7, 7)]
        [InlineData("i9", false, -1, -1)] // некоректна позиція
        public void ParsePosition_ValidInput_ReturnsCorrectCoordinates(string position, bool expectedResult, int expectedX, int expectedY)
        {
            int x, y;
            bool result = Utils.ParsePosition(position, out x, out y);

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedX, x);
            Assert.Equal(expectedY, y);
        }

        [Fact]
        public void WriteOutput_ValidMoves_WritesCorrectOutput()
        {
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestOutput.txt");
            Utils.CheckFile(outputFilePath);
            Utils.WriteOutput(outputFilePath, 1);
            string output = File.ReadAllText(outputFilePath).Trim();

            Assert.Equal("1", output);
        }

        [Fact]
        public void WriteOutput_InvalidMoves_WritesNo()
        {
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestOutput.txt");
            Utils.CheckFile(outputFilePath);
            Utils.WriteOutput(outputFilePath, -1);
            string output = File.ReadAllText(outputFilePath).Trim();

            Assert.Equal("NO", output);
        }

        [Fact]
        public void CheckFile_ValidatesFileExistence()
        {
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestOutput.txt");
            Utils.CheckFile(outputFilePath);
            Assert.True(File.Exists(outputFilePath));
        }
    }
}