using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Utils
    {
        public static void WriteOutput(string path, int moves) // Запис у файл
        {
            if (moves == 1 || moves == 2)
                File.WriteAllText(path, moves.ToString());
            else
                File.WriteAllText(path, "NO");
        }

        public static void CheckFile(string path) // Перевірка файлу
        {
            if (File.Exists(path))
                File.WriteAllText(path, string.Empty);
            else
                File.Create(path).Close();
        }

        public static bool GetCoordinates(string[] positions, out int startX, out int startY, out int endX, out int endY) // отримання координат
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

        public static bool ParsePosition(string position, out int x, out int y) // Перевірка координат
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
    }
}
