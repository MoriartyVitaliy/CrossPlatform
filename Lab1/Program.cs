namespace Lab1
{
    static class Program
    {
        static readonly int[] knightMovesX = { 2, 2, 1, 1, -1, -1, -2, -2 };
        static readonly int[] knightMovesY = { 1, -1, 2, -2, 2, -2, 1, -1 };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] board = new int[8, 8];
            bool[,] visited = new bool[8, 8]; // Масив для відвіданих клітинок

            int startX, startY, endX, endY; // Ініціалізуємо змінні

            if (!GetCoordinates(args, out startX, out startY, out endX, out endY))
            {
                Console.Error.WriteLine("Ой, щось пішло не так...");
                return;
            }

            int moves = Move(board, visited, startX, startY, endX, endY, 0);

            Console.WriteLine(moves == -1 ? "Забагато ходів" : $"Кількість ходів: {moves}");
        }

        static bool GetCoordinates(string[] args, out int startX, out int startY, out int endX, out int endY)
        {
            startX = startY = endX = endY = -1;

            if (args.Length == 4)
            {
                // Якщо передані аргументи через командний рядок
                if (ValidateInput(args, out startX, out startY, out endX, out endY))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Потрібно ввести коректні координати через командний рядок у форматі: x-start y-start x-end y-end");
                    return false;
                }
            }

            // Якщо аргументи не передані, просимо ввести вручну
            Console.WriteLine("Введіть координати через пробіл: x-start y-start x-end y-end");
            string[] input = Console.ReadLine().Split(' ');

            while (!ValidateInput(input, out startX, out startY, out endX, out endY))
            {
                Console.WriteLine("Неправильно введені дані. Будь ласка, введіть координати у форматі: x-start y-start x-end y-end");
                input = Console.ReadLine().Split(' ');
            }

            return true;
        }

        static bool ValidateInput(string[] input, out int startX, out int startY, out int endX, out int endY)
        {
            startX = startY = endX = endY = -1;

            if (input.Length != 4)
                return false;

            return int.TryParse(input[0], out startX) && startX >= 0 && startX < 8 &&
                   int.TryParse(input[1], out startY) && startY >= 0 && startY < 8 &&
                   int.TryParse(input[2], out endX) && endX >= 0 && endX < 8 &&
                   int.TryParse(input[3], out endY) && endY >= 0 && endY < 8;
        }

        public static bool IsMovePossible(int x, int y, int[,] board, bool[,] visited) // Чи можна ходити
        {
            return x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1) && !visited[x, y];
        }

        public static int Move(int[,] board, bool[,] visited, int startX, int startY, int endX, int endY, int steps)
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

                if (IsMovePossible(x, y, board, visited))
                {
                    int result = Move(board, visited, x, y, endX, endY, steps + 1);

                    if (result != -1)
                        minSteps = Math.Min(minSteps, result);
                }
            }

            return minSteps == int.MaxValue ? -1 : minSteps;
        }
    }
}
