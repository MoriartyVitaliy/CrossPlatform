using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Solution
    {
        static readonly int[] knightMovesX = { 2, 2, 1, 1, -1, -1, -2, -2 };
        static readonly int[] knightMovesY = { 1, -1, 2, -2, 2, -2, 1, -1 };
        static bool[,] visited = new bool[8, 8]; // Масив для відвіданих клітинок   
        public static bool IsMovePossible(int x, int y) // Чи можна ходити
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8 && !visited[x, y];
        }
        public static int Answer(int startX, int startY, int endX, int endY, int steps)
        {
            if (steps > 2) // Завелика глибина
                return -1;

            if (startX == endX && startY == endY) // Фініш
                return steps;

            visited[startX, startY] = true; // Вже були

            int minSteps = int.MaxValue;

            for (int i = 0; i < knightMovesX.Length; i++)
            {
                int x = startX + knightMovesX[i];
                int y = startY + knightMovesY[i];

                if (IsMovePossible(x, y))
                {
                    int result = Answer(x, y, endX, endY, steps + 1);

                    if (result != -1)
                        minSteps = Math.Min(minSteps, result);
                }
            }

            return minSteps == int.MaxValue ? -1 : minSteps;
        }
    }
}
