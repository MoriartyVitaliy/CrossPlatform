using McMaster.Extensions.CommandLineUtils;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using LabsLibrary;
using Microsoft.Win32;
using System.Diagnostics;

namespace Lab4
{
    // Головний клас програми
    [Subcommand(typeof(VersionCommand), typeof(Run), typeof(SetPathCommand), typeof(ShowPathCommand))]
    [HelpOption("-h|--help")]
    public class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            Console.WriteLine("Please specify a command (version, run, set-path).");
        }
    }

    // Команда для виведення версії програми
    [Command(Name = "version", Description = "Version of program")]
    class VersionCommand
    {
        private void OnExecute()
        {
            Console.WriteLine("Author: Hriss Vitalii");
            Console.WriteLine("Version: 1.0");
        }
    }

    // Команда для запуску лабораторної роботи
    [Command(Name = "run", Description = "Run the program")]
    class Run
    {
        [Required]
        [Argument(0)]
        public string? LabName { get; }

        [Option("-i|--input", Description = "Input file path")]
        public string? InputPath { get; }

        [Option("-o|--output", Description = "Output file path")]
        public string? OutputPath { get; }

        private readonly string[] _labNames = { "Lab1", "Lab2", "Lab3" };

        private void OnExecute()
        {
            if (string.IsNullOrEmpty(LabName))
            {
                Console.WriteLine("Error: Lab name is required.");
                return;
            }
            string processedLabName = ProcessLabStringName(LabName);

            if (!_labNames.Contains(processedLabName))
            {
                Console.WriteLine("Error: Invalid lab name.");
                Console.WriteLine($"Available labs: {string.Join(", ", _labNames)}");
                return;
            }

            Console.WriteLine($"Running {processedLabName}...");

            Debugger.Launch();

            string inputFilePath = ResolveFilePath(InputPath, "INPUT.txt");
            if (string.IsNullOrEmpty(inputFilePath))
            {
                Console.WriteLine("Error: Input file could not be found.");
                return;
            }

            string outputFilePath = ResolveFilePath(OutputPath, "OUTPUT.txt");
            if (string.IsNullOrEmpty(outputFilePath))
            {
                Console.WriteLine("Error: Output file could not be found. Creating output.txt in the same directory as input.txt ...");
                string? directory = Path.GetDirectoryName(inputFilePath);
                if (string.IsNullOrEmpty(directory))
                {
                    Console.WriteLine("Error: Could not determine directory of input file.");
                    return;
                }
                outputFilePath = Path.Combine(directory, "output.txt");
            }

            try
            {
                Console.WriteLine($"Path to input file: {inputFilePath}\nPath to output file: {outputFilePath}");
                LabExecutor.ExecuteLab(processedLabName, inputFilePath, outputFilePath);
                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during execution: " + ex.Message);
            }
        }

        private static string ProcessLabStringName(string labName)
        {
            labName = labName.ToLower();
            return char.ToUpper(labName[0]) + labName.Substring(1);
        }

        private static string ResolveFilePath(string? consolePath, string fileName)
        {
            if (!string.IsNullOrEmpty(consolePath) && File.Exists(consolePath))
            {
                return consolePath;
            }

            EnvironmentVariableTarget target = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? EnvironmentVariableTarget.User
                : EnvironmentVariableTarget.Process;

            string envPath = Environment.GetEnvironmentVariable("LAB_PATH", target);

            if (!string.IsNullOrEmpty(envPath))
            {
                string envFilePath = FindFileIgnoreCase(envPath, fileName);
                if (!string.IsNullOrEmpty(envFilePath))
                {
                    return envFilePath;
                }
            }

            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var homeFilePath = FindFileIgnoreCase(homePath, fileName);
            if (!string.IsNullOrEmpty(homeFilePath))
            {
                return homeFilePath;
            }

            return string.Empty;
        }

        private static string FindFileIgnoreCase(string directory, string fileName)
        {
            foreach (var file in Directory.EnumerateFiles(directory, fileName, SearchOption.TopDirectoryOnly))
            {
                if (string.Equals(Path.GetFileName(file), fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return file;
                }
            }
            return string.Empty;
        }
    }


        [Command(Name = "set-path", Description = "Set the path for input and output files directory")]
    class SetPathCommand
    {
        [Required]
        [Option("-p|--path", Description = "Path to the folder with input and output files", ShowInHelpText = true)]
        public string? PathToFolder { get; }

        private void OnExecute()
        {
            try
            {
                if (string.IsNullOrEmpty(PathToFolder))
                {
                    Console.WriteLine("Error: PathToFolder is null or empty.");
                    return;
                }

                // Проверяем доступность директории
                if (!Directory.Exists(PathToFolder))
                {
                    Console.WriteLine($"Error: Directory '{PathToFolder}' does not exist.");
                    return;
                }

                // Определяем цель переменной окружения
                EnvironmentVariableTarget target = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
                    ? EnvironmentVariableTarget.User 
                    : EnvironmentVariableTarget.Process;

                // Устанавливаем переменную окружения
                Environment.SetEnvironmentVariable("LAB_PATH", PathToFolder, target);

                // Проверяем, что переменная сохранена корректно
                string? savedPath = Environment.GetEnvironmentVariable("LAB_PATH", target);
                if (savedPath == PathToFolder)
                {
                    Console.WriteLine($"LAB_PATH successfully set to: {savedPath}");
                }
                else
                {
                    Console.WriteLine("Failed to set LAB_PATH correctly.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting LAB_PATH: " + ex.Message);
            }
        }
    }

    [Command(Name = "show-path", Description = "Show the current LAB_PATH environment variable")]
    class ShowPathCommand
    {
        private void OnExecute()
        {
            EnvironmentVariableTarget target = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? EnvironmentVariableTarget.User 
                : EnvironmentVariableTarget.Process;

            string? labPath = Environment.GetEnvironmentVariable("LAB_PATH", target);
            if (string.IsNullOrEmpty(labPath))
            {
                Console.WriteLine("LAB_PATH is not set.");
            }
            else
            {
                Console.WriteLine($"LAB_PATH: {labPath}");
            }
        }
    }


}