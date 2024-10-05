using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Tests
{
    public class UtilsTests
    {
        private const string TestFilePath = "testINPUT.txt";
        [Fact]
        public void ReadInput_Should_Return_NonEmpty_String()
        {
            // Arrange
            File.WriteAllText(TestFilePath, "5\r\n5005 1 5004 2 5003 3 5002 4 5001 5\r\n");

            // Act
            string result = Utils.ReadInput(TestFilePath);

            // Assert
            Assert.Equal("5\r\n5005 1 5004 2 5003 3 5002 4 5001 5", result);
            File.Delete(TestFilePath);
        }

        [Fact]
        public void EmptyFile_Should_Create_Empty_File()
        {
            // Arrange
            Utils.EmptyFile(TestFilePath);

            // Act
            string content = File.ReadAllText(TestFilePath);

            // Assert
            Assert.Empty(content);
            File.Delete(TestFilePath);
        }

        [Fact]
        public void WriteOutput_Should_Create_File_With_Value()
        {
            // Arrange
            int minRisk = 100;

            // Act
            bool result = Utils.WriteOutput(TestFilePath, minRisk);
            string content = File.ReadAllText(TestFilePath);

            // Assert
            Assert.True(result);
            Assert.Equal("100", content);
            File.Delete(TestFilePath);
        }
        [Theory]
        [InlineData("3 25 10 30 20 35 30", 3, new int[] { 25, 30, 35 }, new int[] { 10, 20, 30 })]
        public void FillArray_Should_Initialize_Agents_Correctly(string input, int expectedN, int[] expectedAges, int[] expectedRisks)
        {
            // Act
            bool result = Utils.FillArray(input, out int n, out Agent[] agents);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedN, n);
            for (int i = 0; i < n; i++)
            {
                Assert.Equal(expectedAges[i], agents[i].Age);
                Assert.Equal(expectedRisks[i], agents[i].Risk);
            }
        }

        [Fact]
        public void FillArray_Should_Return_False_On_Invalid_Input()
        {
            // Arrange
            string input = "Invalid input";

            // Act
            bool result = Utils.FillArray(input, out int n, out Agent[] agents);

            // Assert
            Assert.False(result);
            Assert.Equal(0, n);
            Assert.Null(agents);
        }
    }
}
