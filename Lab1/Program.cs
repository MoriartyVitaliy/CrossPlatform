using System;
using System.IO;

namespace Lab1
{
    public static class Program
    {
        public static void Main(string inputFile, string outputFile)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {

                string input =  File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt")).Trim();
                string[] positions = input.Split(", ");
                int startX, startY, endX, endY;


                if (!Utils.GetCoordinates(positions, out startX, out startY, out endX, out endY))
                {
                    Console.Error.WriteLine("Некоректні координати у файлі INPUT.TXT.");
                    return;
                }

                Utils.CheckFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"));

                // 1 хід
                if (Solution.IsMoveValid(startX, startY, endX, endY))
                {
                    Utils.WriteOutput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"), 1);
                    return;
                }

                int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
                int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

                // 2 ходи
                for (int i = 0; i < 8; ++i)
                {
                    if (Solution.IsMoveValid(startX + dx[i], startY + dy[i], endX, endY))
                    {
                        Utils.WriteOutput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"), 2);
                        return;
                    }
                }

                // Не вийшло
                Utils.WriteOutput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"), -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
