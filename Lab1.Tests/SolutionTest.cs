namespace Lab1.Tests
{
    public class SolutionTests
    {
        [Theory]
        [InlineData(0, 0, 2, 1, 1)] // 1 ход
        [InlineData(0, 0, 2, 4, 2)] // 2 хода
        [InlineData(0, 0, 7, 7, -1)] // Недостижимо
        [InlineData(0, 0, 0, 0, 0)] // Уже на месте
        public void Answer_ValidInput_ReturnsCorrectSteps(int startX, int startY, int endX, int endY, int expectedMoves)
        {
            // Проверка для 1 хода
            if (expectedMoves == 1)
            {
                Assert.True(Solution.IsMoveValid(startX, startY, endX, endY));
            }
            // Проверка для 2 ходов
            else if (expectedMoves == 2)
            {
                bool foundInTwoMoves = false;
                int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
                int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

                for (int i = 0; i < 8 && !foundInTwoMoves; ++i)
                {
                    foundInTwoMoves = Solution.IsMoveValid(startX + dx[i], startY + dy[i], endX, endY);
                }

                Assert.True(foundInTwoMoves);
            }
            // Проверка для недостижимой позиции
            else
            {
                Assert.False(Solution.IsMoveValid(startX, startY, endX, endY));
            }
        }
    }
}
