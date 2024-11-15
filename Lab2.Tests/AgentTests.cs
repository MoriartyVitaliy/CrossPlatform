using Lab2.Library;

namespace Lab2.Tests
{

    public class AgentTests
    {
        [Fact]
        public void Agent_Constructor_Should_Set_Properties()
        {
            // Arrange
            int age = 30;
            int risk = 100;

            // Act
            var agent = new Agent(age, risk);

            // Assert
            Assert.Equal(age, agent.Age);
            Assert.Equal(risk, agent.Risk);
        }

        [Theory]
        [InlineData(25, 50)]
        [InlineData(35, 70)]
        [InlineData(45, 90)]
        public void Agent_Constructor_Should_Set_Properties_For_Multiple_Agents(int age, int risk)
        {
            // Act
            var agent = new Agent(age, risk);

            // Assert
            Assert.Equal(age, agent.Age);
            Assert.Equal(risk, agent.Risk);
        }
    }
}