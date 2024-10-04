using System;
using System.IO;

namespace Lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            string input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\INPUT.txt")).Trim();
            string[] positions = input.Split(", ");
            int startX, startY, endX, endY;

            if (!Utils.GetCoordinates(positions, out startX, out startY, out endX, out endY))
            {
                Console.Error.WriteLine("Некоректні координати у файлі INPUT.TXT.");
                return;
            }                                       

            try {
                Utils.CheckFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"));
                Utils.WriteOutput(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\OUTPUT.txt"), Solution.Answer(startX, startY, endX, endY, 0));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
