using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Library
{
    public static class Utils
    {
        public static string ReadInput(string path) // Чтение 
        {
            try
            {
                return File.ReadAllText(path).Trim();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static void EmptyFile(string path) // Удаление 
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
                return;
            }
            File.Create(path).Close();
        }
        public static bool WriteOutput(string path, int minRisk) // Запись
        {
            try
            {
                File.WriteAllText(path, minRisk.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool FillArray(string input, out int n, out Agent[]? agents) // Заполнение
        {
            try
            {
                string[] data = input.Split(new char[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                n = Convert.ToInt32(data[0]);
                agents = new Agent[n];

                for (int i = 0; i < n; i++)
                {
                    int age = int.Parse(data[2 * i + 1]);
                    int risk = int.Parse(data[2 * i + 2]);
                    agents[i] = new Agent(age, risk);
                }
                Array.Sort(agents, (a, b) => a.Age - b.Age);
                return true;
            }
            catch (Exception)
            {
                n = 0;
                agents = null;
                return false;
            }
        }
    }
}
