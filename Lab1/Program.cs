using System;
using System.IO;

namespace Lab1
{
    static class Program
    {
        static readonly int[] knightMovesX = { 2, 2, 1, 1, -1, -1, -2, -2 };
        static readonly int[] knightMovesY = { 1, -1, 2, -2, 2, -2, 1, -1 };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            
            string input = File.ReadAllText("INPUT.txt").Trim();
            string[] positions = input.Split(", ");
            int startX, startY, endX, endY;

            if (!GetCoordinates(positions, out startX, out startY, out endX, out endY))
            {
                Console.Error.WriteLine("Некоректні координати у файлі INPUT.TXT.");
                return;
            }

            bool[,] visited = new bool[8, 8]; // Масив для відвіданих клітинок

            int moves = Move(visited, startX, startY, endX, endY, 0);

            try {
                CheckFile("OUTPUT.TXT");
                WriteOutput("OUTPUT.TXT", moves);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        static bool WriteInput(string path, string input)
        {
            try
            {
                File.WriteAllText(path, input);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        static void WriteOutput(string path, int moves)
        {
            if (moves == 1 || moves == 2)
                File.WriteAllText(path, moves.ToString());
            else
                File.WriteAllText(path, "NO");
        }

        static void CheckFile(string path)
        {
            if (File.Exists(path))
                File.WriteAllText(path, string.Empty);
            else
                File.Create(path).Close();
        }

        static bool GetCoordinates(string[] positions, out int startX, out int startY, out int endX, out int endY)
        {
            startX = startY = endX = endY = -1;

            if (positions.Length == 2 &&
                ParsePosition(positions[0], out startX, out startY) &&
                ParsePosition(positions[1], out endX, out endY))
            {
                return true;
            }

            return false;
        }

        static bool ParsePosition(string position, out int x, out int y)
        {
            x = y = -1;
            if (position.Length != 2) return false;

            char file = position[0];
            char rank = position[1];

            if (file < 'a' || file > 'h' || rank < '1' || rank > '8') return false;

            x = file - 'a'; 
            y = rank - '1'; 

            return true;
        }

        public static bool IsMovePossible(int x, int y, bool[,] visited) // Чи можна ходити
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8 && !visited[x, y];
        }

        public static int Move(bool[,] visited, int startX, int startY, int endX, int endY, int steps)
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

                if (IsMovePossible(x, y, visited))
                {
                    int result = Move(visited, x, y, endX, endY, steps + 1);

                    if (result != -1)
                        minSteps = Math.Min(minSteps, result);
                }
            }

            return minSteps == int.MaxValue ? -1 : minSteps;
        }
    }
}
