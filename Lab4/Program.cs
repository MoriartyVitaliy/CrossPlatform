using System;
using System.IO;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid command. Please use 'version', 'run', or 'set-path'.");
                return;
            }

            switch (args[0].ToLower())
            {
                case "version":
                    ShowVersion();
                    break;
                case "run":
                    RunLab(args);
                    break;
                case "set-path":
                    SetPath(args);
                    break;
                default:
                    Console.WriteLine("Unknown command. Use 'version', 'run', or 'set-path'.");
                    break;
            }
        }

        // Показывает информацию о версии программы
        private static void ShowVersion()
        {
            Console.WriteLine("MyLabsApp v1.0");
            Console.WriteLine("Author: Vitalii Hriss");
        }

        // Запускает лабораторные работы в зависимости от команды
        private static void RunLab(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("You need to specify a lab (lab1, lab2, or lab3).");
                return;
            }

            string labName = args[1].ToLower();
            string inputFile = GetFilePath(args, "-I", "--input");
            string outputFile = GetFilePath(args, "-o", "--output");

            switch (labName)
            {
                case "lab1":
                    RunLab1(inputFile, outputFile);
                    break;
                case "lab2":
                    RunLab2(inputFile, outputFile);
                    break;
                case "lab3":
                    RunLab3(inputFile, outputFile);
                    break;
                default:
                    Console.WriteLine("Unknown lab. Use 'lab1', 'lab2', or 'lab3'.");
                    break;
            }
        }

        // Обрабатывает команду set-path
        private static void SetPath(string[] args)
        {
            // Получаем путь, переданный в командной строке
            string basePath = GetFilePath(args, "-p", "--path");

            // Проверка на наличие пути
            if (string.IsNullOrEmpty(basePath))
            {
                Console.WriteLine("You must specify the path.");
                return;
            }

            // Создаем полный путь для хранения файлов лабораторных работ
            string labPath = Path.Combine(basePath, "LabFiles");

            // Если директория LabFiles не существует, создаем ее
            if (!Directory.Exists(labPath))
            {
                Directory.CreateDirectory(labPath);
                Console.WriteLine($"Directory '{labPath}' created.");
            }

            // Устанавливаем переменную окружения LAB_PATH
            Environment.SetEnvironmentVariable("LAB_PATH", labPath);
            Console.WriteLine($"LAB_PATH is set to: {labPath}");
        }


        // Получает путь к файлу из аргументов
        private static string GetFilePath(string[] args, string shortOption, string longOption)
        {
            int index = Array.IndexOf(args, shortOption);
            if (index == -1)
                index = Array.IndexOf(args, longOption);

            if (index != -1 && index + 1 < args.Length)
                return args[index + 1];

            return null;
        }

        // Запуск лабораторной работы 1
        private static void RunLab1(string inputFile, string outputFile)
        {
            Console.WriteLine("Running Lab 1...");
            Lab1.Program.Main(inputFile, outputFile);

        }

        // Запуск лабораторной работы 2
        private static void RunLab2(string inputFile, string outputFile)
        {
            Console.WriteLine("Running Lab 2...");
            Lab2.Program.Main(inputFile, outputFile);

        }

        // Запуск лабораторной работы 3
        private static void RunLab3(string inputFile, string outputFile)
        {
            Console.WriteLine("Running Lab 3...");
            Lab3.Program.Main(inputFile, outputFile);

        }
    }
}
