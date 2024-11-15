using Lab2.Library;

namespace Lab2.Tests
{
    public class SolutionTests
    {
        [Fact]
        public void MinValue_Should_Calculate_MinRisk_For_Simple_Case()
        {
            // Arrange
            var agents = new[]
            {
                new Agent(5000, 4),
                new Agent(5500, 3),
                new Agent(6000, 2)
            };
            int[] minRisks = new int[agents.Length];

            // Act
            int result = Solution.MinValue(agents.Length, agents, minRisks);

            // Assert
            Assert.Equal(5, result); // Example value, adjust based on actual logic
        }
        [Theory]
        [InlineData(3, new int[] { 4, 3, 2 }, 5)]
        [InlineData(5, new int[] { 1, 2, 3, 4, 5 }, 9)]
        public void MinValue_Should_Calculate_MinRisk_With_Various_Agents(int n, int[] risks, int expectedMinRisk)
        {
            // Arrange
            Agent[] agents = new Agent[n];
            for (int i = 0; i < n; i++)
            {
                agents[i] = new Agent(i * 5 + 20, risks[i]);
            }

            int[] minRisks = new int[n];

            // Act
            int result = Solution.MinValue(n, agents, minRisks);

            // Assert
            Assert.Equal(expectedMinRisk, result);
        }
    }
}
